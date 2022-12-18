using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace PlatformService.Infrastructure.Implementation.MessageBus
{
    internal class PlatformsEventHandler
    {
        private readonly ILogger _logger;

        public PlatformsEventHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void HandleConnectionShutdown(object sender, ShutdownEventArgs eventArgs)
        {
            _logger.LogInformation("RabbitMQ connection shutdown.");
        }
    }
}
