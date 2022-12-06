using AutoMapper;
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
            var entity = _mapper.Map<Platform>(request);

            entity.IsDeleted = false;

            _uow.Platforms.Add(entity);

            await _uow.CommitAsync(cancellationToken);

            return entity.Id;
        }
    }
}
