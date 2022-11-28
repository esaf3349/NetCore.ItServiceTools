using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformService.Persistence.EntityFramework
{
    public static class ServiceScopeExtensions
    {
        public static void ApplyAppDatabaseMigrations(this IServiceScope serviceScope)
        {
            using (var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
