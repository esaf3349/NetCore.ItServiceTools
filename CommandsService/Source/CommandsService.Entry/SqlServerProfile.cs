using CommandsService.Application;
using CommandsService.Infrastructure.Implementation;
using CommandsService.Persistence.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CommandsService.Entry
{
    public class SqlServerProfile
    {
        public static void AddLayers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerPersistence(configuration);

            services.AddMediatrApplication();

            services.AddRabbitMqMessageBus();
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
