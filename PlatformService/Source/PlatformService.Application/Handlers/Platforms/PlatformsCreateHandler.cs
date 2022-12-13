using AutoMapper;
using MediatR;
using PlatformService.Application.Models.Platforms;
using PlatformService.Core.Entities;
using PlatformService.Infrastructure.Interfaces.Dtos.Http.CommandsDataClient;
using PlatformService.Infrastructure.Interfaces.Dtos.MessageBus.MessageBusClient;
using PlatformService.Infrastructure.Interfaces.Services.Http;
using PlatformService.Infrastructure.Interfaces.Services.MessageBus;
using PlatformService.Persistence.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Application.Handlers.Platforms
{
    public class PlatformsCreateHandler : IRequestHandler<PlatformsCreateCommand, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICommandsDataClient _commandsDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public PlatformsCreateHandler(IUnitOfWork uow, IMapper mapper, ICommandsDataClient commandsDataClient, IMessageBusClient messageBusClient)
        {
            _uow = uow;
            _mapper = mapper;
            _commandsDataClient = commandsDataClient;
            _messageBusClient = messageBusClient;
        }

        public async Task<int> Handle(PlatformsCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Platform>(request);

            entity.IsDeleted = false;

            _uow.Platforms.Add(entity);

            await _uow.CommitAsync(cancellationToken);

            var httpClientDto = _mapper.Map<PlatformsCreateDto>(entity);

            await _commandsDataClient.SendPlatformToCommandsService(httpClientDto, cancellationToken);

            var messageBusDto = _mapper.Map<PlatformsPublishDto>(entity);
            messageBusDto.Event = "Create";

            _messageBusClient.PlatformsPublish(messageBusDto);

            return entity.Id;
        }
    }
}