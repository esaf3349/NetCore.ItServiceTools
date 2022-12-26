using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using PlatformService.Infrastructure.Implementation.Grpc;
using System.IO;

namespace PlatformService.Infrastructure.Implementation
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder AddGrpcServices(this IEndpointRouteBuilder builder) 
        {
            builder.MapGrpcService<PlatformsSeedDataService>();

            builder.MapGet("/protos/platforms/get/all", async context =>
            {
                await context.Response.WriteAsync(File.ReadAllText("../PlatformService.Infrastructure.Interfaces/Services/Grpc/Protos/platformsGetAll.proto"));
            });

            return builder;
        }
    }
}
