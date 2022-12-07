using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PlatformService.Infrastructure.Interfaces.Dtos.CommandsDataClient;
using PlatformService.Infrastructure.Interfaces.Http;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Implementation.Http
{
    public class CommandsDataClient : ICommandsDataClient
    {
        private readonly IConfiguration _config;
        private readonly ILogger<CommandsDataClient> _logger;
        private readonly HttpClient _httpClient;

        public CommandsDataClient(IConfiguration config, ILogger<CommandsDataClient> logger, HttpClient httpClient)
        {
            _config = config;
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task SendPlatformToCommandsService(PlatformsCreateDto platform, CancellationToken cancellationToken = default)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(platform));

            try
            {
                var response = await _httpClient.PostAsync(_config["CommandsService:Endpoint"] + _config["PlatformsController:CreatePath"], httpContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not send synchronous message to CommandsService.");
            }
        }
    }
}
