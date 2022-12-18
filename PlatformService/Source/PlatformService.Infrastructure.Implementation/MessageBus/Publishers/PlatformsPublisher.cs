using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PlatformService.Infrastructure.Interfaces.Dtos.MessageBus.MessageBusClient;
using PlatformService.Infrastructure.Interfaces.Services.MessageBus;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

namespace PlatformService.Infrastructure.Implementation.MessageBus.Publishers
{
    public class PlatformsPublisher : IPlatformsMessageBusPublisher
    {
        private readonly IConfiguration _config;
        private readonly ILogger<PlatformsPublisher> _logger;

        private PlatformsEventHandler _platformsEventHandler;

        private IConnection _connection;
        private IModel _channel;
        private string _exchangeName;
        private bool _isDisposed = false;

        public PlatformsPublisher(IConfiguration config, ILogger<PlatformsPublisher> logger)
        {
            _config = config;
            _logger = logger;

            _platformsEventHandler = new PlatformsEventHandler(_logger);

            Connect();
        }

        private void Connect()
        {
            try
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
                _connection.ConnectionShutdown += _platformsEventHandler.HandleConnectionShutdown;

                _logger.LogInformation("Connected to message bus.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not connect to the message bus.");
            }
        }

        public void Publish(PlatformsCreateEventDto platform)
        {
            var message = JsonSerializer.Serialize(platform);

            if (_connection.IsOpen)
            {
                var body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish(_exchangeName, string.Empty, null, body);

                _logger.LogInformation($"RabbitMQ connection is open, sending message {message}.");
            }
            else
            {
                _logger.LogInformation("RabbitMQ connection is closed, not sending.");
            }
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

        public void Dispose()
        {
            Cleanup(true);
            GC.SuppressFinalize(this);
        }
    }
}
