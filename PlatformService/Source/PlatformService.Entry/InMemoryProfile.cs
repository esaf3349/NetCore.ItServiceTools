using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Application;
using PlatformService.Persistence.EntityFramework;

namespace PlatformService.Entry
{
    public class InMemoryProfile
    {
        public static void AddLayers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddInMemoryPersistence(configuration);

            services.AddMediatrApplication();
        }

        public static void RunStartupActions(IServiceScope serviceScope)
        {

        }
    }
}
