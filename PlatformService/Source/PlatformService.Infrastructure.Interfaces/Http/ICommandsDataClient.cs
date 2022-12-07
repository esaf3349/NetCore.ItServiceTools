using PlatformService.Infrastructure.Interfaces.Dtos.CommandsDataClient;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Interfaces.Http
{
    public interface ICommandsDataClient
    {
        Task SendPlatformToCommandsService(PlatformsCreateDto platform, CancellationToken cancellationToken = default);
    }
}
