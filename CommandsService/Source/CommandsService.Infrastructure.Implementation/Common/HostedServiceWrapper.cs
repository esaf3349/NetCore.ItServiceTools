using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Infrastructure.Implementation.Common
{
    internal class HostedServiceWrapper<TService> : IHostedService
    {
        private readonly IHostedService _hostedService;

        public HostedServiceWrapper(TService hostedService)
        {
            _hostedService = (IHostedService)hostedService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return _hostedService.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _hostedService.StopAsync(cancellationToken);
        }
    }
}
