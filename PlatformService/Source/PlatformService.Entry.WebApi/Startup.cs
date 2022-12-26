using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PlatformService.Entry.WebApi.Middlewares;
using AppProfile = PlatformService.Entry.SqlServerProfile;

namespace PlatformService.Entry.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AppProfile.AddLayers(services, Configuration);

            services.AddControllers();

            services.AddSwaggerGen(options => options
                .SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PlatformService",
                    Version = "v1"
                }));
        }

        public void Configure(IApplicationBuilder builder, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                builder.UseDeveloperExceptionPage();
            }

            builder.UseHttpsRedirection();

            builder.UseMiddleware<AppExceptionHandlerMiddleware>();

            builder.UseHttpsRedirection();

            builder.UseSwagger();

            builder.UseSwaggerUI();

            builder.UseRouting();

            builder.UseAuthorization();

            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                AppProfile.AddEndpoints(endpoints);
            });

            using (var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                AppProfile.InitializeDb(serviceScope);
            }
        }
    }
}
