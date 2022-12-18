using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CommandsService.Infrastructure.Implementation.Common;
using CommandsService.Infrastructure.Implementation.MappingProfiles;
using CommandsService.Infrastructure.Interfaces.Services.MessageBus.EventProcessors;
using CommandsService.Infrastructure.Implementation.Services.EventProcessors;
using CommandsService.Infrastructure.Implementation.Services.Subscribers;
using CommandsService.Infrastructure.Interfaces.Services.MessageBus.Subscribers;

namespace CommandsService.Infrastructure.Implementation
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMqInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PlatformsMappingProfile));

            services.AddHostedService<IPlatformsSubscriber, PlatformsSubscriber>();

            services.AddScoped<IPlatformsEventProcessor, PlatformsMediatrEventProcessor>();

            return services;
        }

        private static IServiceCollection AddHostedService<TService, TImplementation>(this IServiceCollection services) 
            where TService : class 
            where TImplementation : class, IHostedService, TService
        {
            services.AddSingleton<TService, TImplementation>();
            services.AddHostedService<HostedServiceWrapper<TService>>();

            return services;
        }
    }
}
