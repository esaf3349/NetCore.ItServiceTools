using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Application;
using PlatformService.Infrastructure.Implementation;
using PlatformService.Persistence.EntityFramework;

namespace PlatformService.Entry
{
    public class InMemoryProfile
    {
        public static void AddLayers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddInMemoryPersistence(configuration);

            services.AddMediatrApplication();

            services.AddInfrastructureImplementation();
        }

        public static void AddEndpoints(IEndpointRouteBuilder builder)
        {
            builder.AddGrpcServices();
        }

        public static void InitializeDb(IServiceScope serviceScope)
        {

        }
    }
}
