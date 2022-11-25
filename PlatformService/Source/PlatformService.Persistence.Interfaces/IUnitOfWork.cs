using PlatformService.Persistence.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlatformRepository Platforms { get; }

        Task CommitAsync(CancellationToken cancellationToken);
    }
}
