using CommandsService.Infrastructure.Interfaces;
using CommandsService.Infrastructure.Interfaces.Services.Grpc;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace CommandsService.Infrastructure.Implementation.Services.Grpc
{
    public class PlatformsSeedDataClient : IPlatformsSeedDataClient
    {
        private readonly IConfiguration _config;
        private readonly ILogger<PlatformsSeedDataClient> _logger;

        public PlatformsSeedDataClient(IConfiguration config, ILogger<PlatformsSeedDataClient> logger)
        {
            _config = config;
            _logger = logger;
        }

        public PlatformsGetAllVm Get()
        {
            _logger.LogInformation($"Calling GRPC service \"{_config["Grpc:Platforms:Endpoint"]}\"");

            var channel = GrpcChannel.ForAddress(_config["Grpc:Platforms:Endpoint"]);
            var client = new PlatformsGrpcService.PlatformsGrpcServiceClient(channel);

            var request = new PlatformsGetAllRequest();

            try
            {
                var reply = client.PlatformsGetAll(request);

                return reply;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not call GRPC server \"{_config["Grpc:Platforms:Endpoint"]}\"");

                return new PlatformsGetAllVm();
            }
        }
    }
}
