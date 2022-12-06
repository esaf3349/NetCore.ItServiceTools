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
    public class PlatformsDeleteHandler : IRequestHandler<PlatformsDeleteCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PlatformsDeleteHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PlatformsDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.Platforms.GetOneAsync(filter => filter.Id == request.Id && filter.IsDeleted == false, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Platform), request.Id);

            entity.IsDeleted = true;

            _uow.Platforms.Update(entity);

            await _uow.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
