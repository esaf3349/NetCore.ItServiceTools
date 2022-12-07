using CommandsService.Application.Common.PipelineBehaviors;
using CommandsService.Application.MappingProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CommandsService.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatrApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommandsMappingProfile), typeof(PlatformsMappingProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
