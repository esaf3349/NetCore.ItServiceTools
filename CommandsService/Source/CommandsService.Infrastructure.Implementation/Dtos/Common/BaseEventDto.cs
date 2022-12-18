using CommandsService.Infrastructure.Interfaces.Dtos.MessageBus;

namespace CommandsService.Infrastructure.Implementation.Dtos.Common
{
    public class BaseEventDto : IEventDto
    {
        public string Type { get; set; }
    }
}
