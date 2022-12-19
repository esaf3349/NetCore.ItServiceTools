using AutoMapper;
using CommandsService.Application.Common.Exceptions;
using CommandsService.Application.Models.Platforms;
using CommandsService.Core.Entities;
using CommandsService.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Application.Handlers.Platforms
{
    public class PlatformsCreateHandler : IRequestHandler<PlatformsCreateCommand, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PlatformsCreateHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
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

            return entity.Id;
        }
    }
}
