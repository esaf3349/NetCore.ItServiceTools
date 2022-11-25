using Microsoft.EntityFrameworkCore;
using PlatformService.Core.Entities;
using PlatformService.Persistence.EntityFramework.EntityConfigs;

namespace PlatformService.Persistence.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PlatformEntityConfig());

            base.OnModelCreating(builder);
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}
