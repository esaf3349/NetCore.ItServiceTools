using CommandsService.Infrastructure.Implementation.Services.MessageBus.EventHandlers;
using CommandsService.Infrastructure.Interfaces.Services.MessageBus.Subscribers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Infrastructure.Implementation.Services.MessageBus.Subscribers
{
    public class PlatformsSubscriber : BackgroundService, IPlatformsSubscriber
    {
        private readonly IConfiguration _config;

        private readonly PlatformsEventHandler _platformsEventHandler;

        private IConnection _connection;
        private IModel _channel;
        private string _exchangeName;
        private string _queueName;
        private bool _isDisposed = false;

        public PlatformsSubscriber(IConfiguration config, IServiceScopeFactory serviceScopeFactory)
        {
            _config = config;

            _platformsEventHandler = new PlatformsEventHandler(serviceScopeFactory);

            InitializeSubscription();
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

                _platformsEventHandler.HandleDeliveryReceived(message);
            };

            _channel.BasicConsume(_queueName, true, consumer);

            return Task.CompletedTask;
        }

        private void InitializeSubscription()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _config["RabbitMQ:HostName"],
                Port = int.Parse(_config["RabbitMQ:Port"])
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _exchangeName = _config["RabbitMQ:Exchanges:PlatformsName"];
            _channel.ExchangeDeclare(_exchangeName, ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(_queueName, _exchangeName, routingKey: string.Empty);

            _connection.ConnectionShutdown += (sender, eventArgs) =>
            {
                _platformsEventHandler.HandleConnectionShutdown();
            };
        }

        protected virtual void Cleanup(bool isDisposing)
        {
            if (_isDisposed)
                return;

            if (isDisposing)
            {
                if (_channel.IsOpen)
                    _channel.Close();
                if (_connection.IsOpen)
                    _connection.Close();
            }

            _isDisposed = true;
        }

        public override void Dispose()
        {
            Cleanup(true);
            GC.SuppressFinalize(this);

            base.Dispose();
        }
    }
}
