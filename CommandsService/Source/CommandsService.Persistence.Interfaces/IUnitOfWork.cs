using CommandsService.Persistence.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICommandRepository Commands { get; }
        IPlatformRepository Platforms { get; }

        Task CommitAsync(CancellationToken cancellationToken);
    }
}
