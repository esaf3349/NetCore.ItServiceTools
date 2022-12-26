using AutoMapper;
using CommandsService.Infrastructure.Implementation.Dtos;
using CommandsService.Infrastructure.Interfaces.Services.MessageBus.EventProcessors;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Infrastructure.Implementation.Services.EventProcessors
{
    public class PlatformsMediatrEventProcessor<TMediatrCreateCommand> : IPlatformsEventProcessor where TMediatrCreateCommand : class
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<TMediatrCreateCommand> _logger;

        public PlatformsMediatrEventProcessor(IMediator mediator, IMapper mapper, ILogger<TMediatrCreateCommand> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ProcessCreate(string message, CancellationToken cancellationToken = default)
        {
            var eventDto = JsonSerializer.Deserialize<PlatformsCreateEventDto>(message);
            var request = _mapper.Map<TMediatrCreateCommand>(eventDto);

            try
            {
                await _mediator.Send(request, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not process create event.");
            }
        }
    }
}
