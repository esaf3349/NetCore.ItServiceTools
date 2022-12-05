using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Application.Common.PipelineBehaviors
{
    public class RequestPerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehavior(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                _logger.LogWarning($"Platform service long running request: {name} ({_timer.ElapsedMilliseconds} milliseconds) {@request}");
            }

            return response;
        }
    }
}
