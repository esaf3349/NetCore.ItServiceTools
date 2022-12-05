using CommandsService.Core.Entities;
using CommandsService.Persistence.EntityFramework.Repositories.Common;
using CommandsService.Persistence.Interfaces.Repositories;

namespace CommandsService.Persistence.EntityFramework.Repositories
{
    internal class CommandRepository : GenericRepository<Command>, ICommandRepository
    {
        public CommandRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
