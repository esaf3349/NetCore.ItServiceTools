using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Persistence.Interfaces;

namespace PlatformService.Persistence.EntityFramework
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServerPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppDbConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("PlatformsInMemory"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
