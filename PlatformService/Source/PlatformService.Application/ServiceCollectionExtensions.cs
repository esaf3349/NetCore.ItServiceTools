using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Application.Common.PipelineBehaviors;
using PlatformService.Application.MappingProfiles;
using System.Reflection;

namespace PlatformService.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatrApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PlatformsMappingProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
