using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Application;
using PlatformService.Persistence.EntityFramework;

namespace PlatformService.Entry
{
    public static class SqlServerProfile
    {
        public static void AddLayers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerPersistence(configuration);

            services.AddMediatrApplication();
        }

        public static void RunStartupActions(IServiceScope serviceScope)
        {
            serviceScope.ApplyAppDatabaseMigrations();
        }
    }
}
