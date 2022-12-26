using AutoMapper;
using CommandsService.Application;
using CommandsService.Application.Common.Exceptions;
using CommandsService.Application.Models.Platforms;
using CommandsService.Infrastructure.Implementation;
using CommandsService.Infrastructure.Interfaces.Services.Grpc;
using CommandsService.Persistence.EntityFramework;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Entry
{
    public class InMemoryProfile
    {
        public static void AddLayers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddInMemoryPersistence(configuration);

            services.AddMediatrApplication();

            services.AddRabbitMqMessageBus();

            services.AddInfrastructureImplementation();
        }

        public static void InitializeDb(IServiceScope serviceScope)
        {
            
        }

        public static async Task SeedData(IServiceScope serviceScope, CancellationToken cancellationToken = default)
        {
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<InMemoryProfile>>();
            var mapper = serviceScope.ServiceProvider.GetService<IMapper>();
            var mediator = serviceScope.ServiceProvider.GetService<IMediator>();
            var client = serviceScope.ServiceProvider.GetService<IPlatformsSeedDataClient>();

            var vm = client.Get();

            
            foreach (var platform in vm.Platforms)
            {
                var request = mapper.Map<PlatformsCreateCommand>(platform);

                try
                {
                    await mediator.Send(request, cancellationToken);
                }
                catch (Exception ex)
                {
                    switch (ex)
                    {
                        case AlreadyExistsException:
                            break;
                        default:
                            logger.LogError(ex, "Could not seed the data.");
                            break;
                    }
                }
            }
        }
    }
}
