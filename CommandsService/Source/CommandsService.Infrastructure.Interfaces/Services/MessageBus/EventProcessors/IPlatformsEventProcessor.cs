namespace CommandsService.Infrastructure.Interfaces.Services.MessageBus.EventProcessors
{
    public interface IPlatformsEventProcessor
    {
        void ProcessCreate(string message);
    }
}
