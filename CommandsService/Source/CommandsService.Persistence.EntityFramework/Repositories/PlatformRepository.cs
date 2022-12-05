using CommandsService.Core.Entities;
using CommandsService.Persistence.EntityFramework.Repositories.Common;
using CommandsService.Persistence.Interfaces.Repositories;

namespace CommandsService.Persistence.EntityFramework.Repositories
{
    internal class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
