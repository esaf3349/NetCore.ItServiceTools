﻿using Microsoft.Extensions.DependencyInjection;
using PlatformService.Infrastructure.Implementation.Http;
using PlatformService.Infrastructure.Implementation.MessageBus;
using PlatformService.Infrastructure.Interfaces.Services.Http;
using PlatformService.Infrastructure.Interfaces.Services.MessageBus;

namespace PlatformService.Infrastructure.Implementation
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureImplementation(this IServiceCollection services)
        {
            services.AddHttpClient<ICommandsDataClient, CommandsDataClient>();

            services.AddSingleton<IMessageBusClient, RabbitMqClient>();

            return services;
        }
    }
}
