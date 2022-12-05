using CommandsService.Core.Entities;
using CommandsService.Persistence.EntityFramework.EntityConfigs;
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
            builder.ApplyConfiguration(new CommandEntityConfig());
            builder.ApplyConfiguration(new PlatformEntityConfig());

            base.OnModelCreating(builder);
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Platform> Platforms { get; set; }
    }
}
