using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Infrastructure.Interfaces.Services.MessageBus.EventProcessors
{
    public interface IPlatformsEventProcessor
    {
        Task ProcessCreate(string message, CancellationToken cancellationToken = default);
    }
}
