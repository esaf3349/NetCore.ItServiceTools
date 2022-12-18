using CommandsService.Infrastructure.Implementation.Dtos.Common;
using CommandsService.Infrastructure.Interfaces.Constants.MessageBus;
using CommandsService.Infrastructure.Interfaces.Services.MessageBus.EventProcessors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CommandsService.Infrastructure.Implementation.Services.EventHandlers
{
    public class PlatformsEventHandler
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PlatformsEventHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void HandleConnectionShutdown()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();

                logger.LogInformation("RabbitMQ connection shutdown.");
            }
        }

        public void HandleDeliveryReceived(string message)
        {
            var eventDto = JsonSerializer.Deserialize<BaseEventDto>(message);

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<PlatformsEventHandler>>();
                var eventProcessor = scope.ServiceProvider.GetRequiredService<IPlatformsEventProcessor>();

                switch (eventDto.Type)
                {
                    case MessageBusEvents.Types.Create:
                        logger.LogInformation("RabbitMQ create event received.");
                        eventProcessor.ProcessCreate(message);
                        break;

                    default:
                        logger.LogWarning("RabbitMQ unidentified event received.");
                        break;
                }
            }
        }
    }
}
