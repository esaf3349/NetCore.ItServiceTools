using PlatformService.Infrastructure.Interfaces.Dtos.Http.CommandsDataClient;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Interfaces.Services.Http
{
    public interface ICommandsDataClient
    {
        Task SendPlatformToCommandsService(PlatformsCreateDto platform, CancellationToken cancellationToken = default);
    }
}
