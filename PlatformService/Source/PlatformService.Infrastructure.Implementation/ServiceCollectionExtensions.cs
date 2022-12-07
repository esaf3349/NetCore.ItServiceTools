using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Infrastructure.Implementation.Http;
using PlatformService.Infrastructure.Interfaces.Http;

namespace PlatformService.Infrastructure.Implementation
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureImplementation(this IServiceCollection services)
        {
            services.AddHttpClient<ICommandsDataClient, CommandsDataClient>();

            return services;
        }
    }
}
