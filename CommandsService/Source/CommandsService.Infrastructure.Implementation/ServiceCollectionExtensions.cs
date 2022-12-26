using CommandsService.Infrastructure.Implementation.MappingProfiles;
using CommandsService.Infrastructure.Implementation.Services.Grpc;
using CommandsService.Infrastructure.Interfaces.Services.Grpc;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.Infrastructure.Implementation
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureImplementation(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PlatformsMappingProfile));

            services.AddScoped<IPlatformsSeedDataClient, PlatformsSeedDataClient>();

            return services;
        }
    }
}
