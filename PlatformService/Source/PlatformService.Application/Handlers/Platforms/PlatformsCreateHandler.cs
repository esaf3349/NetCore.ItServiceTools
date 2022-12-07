using AutoMapper;
using MediatR;
using PlatformService.Application.Models.Platforms;
using PlatformService.Core.Entities;
using PlatformService.Infrastructure.Interfaces.Dtos.CommandsDataClient;
using PlatformService.Infrastructure.Interfaces.Http;
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

        public PlatformsCreateHandler(IUnitOfWork uow, IMapper mapper, ICommandsDataClient commandsDataClient)
        {
            _uow = uow;
            _mapper = mapper;
            _commandsDataClient = commandsDataClient;
        }

        public async Task<int> Handle(PlatformsCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Platform>(request);

            entity.IsDeleted = false;

            _uow.Platforms.Add(entity);

            await _uow.CommitAsync(cancellationToken);

            await _commandsDataClient.SendPlatformToCommandsService(new PlatformsCreateDto { ExternalId = entity.Id, Name = request.Name }, cancellationToken);

            return entity.Id;
        }
    }
}