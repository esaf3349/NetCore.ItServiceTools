using CommandsService.Infrastructure.Implementation.Dtos.Common;

namespace CommandsService.Infrastructure.Implementation.Dtos
{
    public class PlatformsCreateEventDto : BaseEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
