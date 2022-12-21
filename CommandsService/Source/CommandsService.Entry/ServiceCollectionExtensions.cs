using CommandsService.Application.Models.Platforms;
using CommandsService.Entry.Common;
using CommandsService.Entry.MappingProfiles.MessageBus;
using CommandsService.Infrastructure.Implementation.Services.EventProcessors;
using CommandsService.Infrastructure.Implementation.Services.Subscribers;
using CommandsService.Infrastructure.Interfaces.Services.MessageBus.EventProcessors;
using CommandsService.Infrastructure.Interfaces.Services.MessageBus.Subscribers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CommandsService.Entry
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMqMessageBus(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RabbitMqMappingProfile));

            services.AddHostedService<IPlatformsSubscriber, PlatformsSubscriber>();

            services.AddScoped<IPlatformsEventProcessor, PlatformsMediatrEventProcessor<PlatformsCreateCommand>>();

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
