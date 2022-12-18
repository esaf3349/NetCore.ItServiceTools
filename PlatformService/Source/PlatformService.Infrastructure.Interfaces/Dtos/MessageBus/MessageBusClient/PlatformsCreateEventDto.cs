namespace PlatformService.Infrastructure.Interfaces.Dtos.MessageBus.MessageBusClient
{
    public class PlatformsCreateEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
