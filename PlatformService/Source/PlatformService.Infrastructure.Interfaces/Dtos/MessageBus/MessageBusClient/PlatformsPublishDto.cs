namespace PlatformService.Infrastructure.Interfaces.Dtos.MessageBus.MessageBusClient
{
    public class PlatformsPublishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Event { get; set; }
    }
}
