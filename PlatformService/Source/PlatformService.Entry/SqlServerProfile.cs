using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlatformService.Application;
using PlatformService.Infrastructure.Implementation;
using PlatformService.Persistence.EntityFramework;
using System;

namespace PlatformService.Entry
{
    public class SqlServerProfile
    {
        public static void AddLayers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerPersistence(configuration);

            services.AddMediatrApplication();

            services.AddInfrastructureImplementation();
        }

        public static void RunStartupActions(IServiceScope serviceScope)
        {
            try
            {
                serviceScope.ApplyAppDatabaseMigrations();
            }
            catch (Exception ex)
            {
                var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<SqlServerProfile>>();
                logger.LogError(ex, "An error occurred while migrating or initializing the database.");
            }
        }
    }
}
