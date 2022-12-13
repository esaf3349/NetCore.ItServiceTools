using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace PlatformService.Infrastructure.Implementation.MessageBus
{
    internal class RabbitMqEventHandlers
    {
        private readonly ILogger _logger;

        public RabbitMqEventHandlers(ILogger logger)
        {
            _logger = logger;
        }

        public void HandleConnectionShutdown(object sender, ShutdownEventArgs e) 
        {
            _logger.LogInformation("RabbitMQ connection shutdown.");
        }
    }
}
