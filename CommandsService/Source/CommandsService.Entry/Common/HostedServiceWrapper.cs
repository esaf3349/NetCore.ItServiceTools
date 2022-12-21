using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;

namespace CommandsService.Entry.Common
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
