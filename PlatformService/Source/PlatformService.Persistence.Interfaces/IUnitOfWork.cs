using PlatformService.Persistence.Interfaces.Repositories;
using System.Threading.Tasks;

namespace PlatformService.Persistence.Interfaces
{
    public interface IUnitOfWork
    {
        IPlatformRepository Platforms { get; }

        Task Commit();
        void Dispose();
    }
}
