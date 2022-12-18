using CommandsService.Application;
using CommandsService.Infrastructure.Implementation;
using CommandsService.Persistence.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.Entry
{
    public class InMemoryProfile
    {
        public static void AddLayers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddInMemoryPersistence(configuration);

            services.AddMediatrApplication();

            services.AddRabbitMqInfrastructure();
        }

        public static void RunStartupActions(IServiceScope serviceScope)
        {

        }
    }
}
