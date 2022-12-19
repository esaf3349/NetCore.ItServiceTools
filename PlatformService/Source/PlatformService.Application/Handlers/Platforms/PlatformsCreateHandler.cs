using AutoMapper;
using MediatR;
using PlatformService.Application.Common.Exceptions;
using PlatformService.Application.Models.Platforms;
using PlatformService.Core.Entities;
using PlatformService.Infrastructure.Interfaces.Constants.MessageBus;
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
        private readonly IPlatformsMessageBusPublisher _messageBusClient;

        public PlatformsCreateHandler(IUnitOfWork uow, IMapper mapper, ICommandsDataClient commandsDataClient, IPlatformsMessageBusPublisher messageBusClient)
        {
            _uow = uow;
            _mapper = mapper;
            _commandsDataClient = commandsDataClient;
            _messageBusClient = messageBusClient;
        }

        public async Task<int> Handle(PlatformsCreateCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _uow.Platforms.GetOneAsync(p => p.Name == request.Name && !p.IsDeleted, cancellationToken);

            if (existingEntity != null)
                throw new AlreadyExistsException(nameof(Platform), nameof(existingEntity.Name), request.Name);

            var entity = _mapper.Map<Platform>(request);

            entity.IsDeleted = false;

            _uow.Platforms.Add(entity);

            await _uow.CommitAsync(cancellationToken);

            var httpClientDto = _mapper.Map<PlatformsCreateDto>(entity);

            await _commandsDataClient.SendPlatformToCommandsService(httpClientDto, cancellationToken);

            var messageBusDto = _mapper.Map<PlatformsCreateEventDto>(entity);
            messageBusDto.Type = MessageBusEvents.Types.Create;

            _messageBusClient.Publish(messageBusDto);

            return entity.Id;
        }
    }
}