using AutoMapper;
using CommandsService.Application.Models.Platforms;
using CommandsService.Infrastructure.Implementation.Dtos;
using CommandsService.Infrastructure.Interfaces.Services.MessageBus.EventProcessors;
using MediatR;
using System.Text.Json;

namespace CommandsService.Infrastructure.Implementation.Services.EventProcessors
{
    public class PlatformsMediatrEventProcessor : IPlatformsEventProcessor
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PlatformsMediatrEventProcessor(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public void ProcessCreate(string message)
        {
            var eventDto = JsonSerializer.Deserialize<PlatformsCreateEventDto>(message);
            var request = _mapper.Map<PlatformsCreateCommand>(eventDto);

            _mediator.Send(request);
        }

        public void ProcessUpdate(string message)
        {
            
        }

        public void ProcessDelete(string message)
        {
            
        }
    }
}
