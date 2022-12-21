using Microsoft.EntityFrameworkCore;
using PlatformService.Core.Entities;

namespace PlatformService.Persistence.EntityFramework
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

        public DbSet<Platform> Platforms { get; set; }
    }
}
