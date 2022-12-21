using CommandsService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Persistence.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Platform> Platforms { get; set; }
    }
}
