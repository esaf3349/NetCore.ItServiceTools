using PlatformService.Core.Entities;
using PlatformService.Persistence.EntityFramework.Repositories.Common;
using PlatformService.Persistence.Interfaces.Repositories;

namespace PlatformService.Persistence.EntityFramework.Repositories
{
    internal class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
