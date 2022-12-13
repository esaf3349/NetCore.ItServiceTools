using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PlatformService.Infrastructure.Interfaces.Dtos.Http.CommandsDataClient;
using PlatformService.Infrastructure.Interfaces.Services.Http;
using System;
using System.Net.Http;
using System.Text;
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
            var httpContent = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(_config["CommandsService:Endpoint"] + _config["CommandsService:PlatformsController:CreatePath"], httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Could not send synchronous message to CommandsService. It returned {response.StatusCode}, reason: \"{response.ReasonPhrase}\".");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not send synchronous message to CommandsService.");
            }
        }
    }
}
