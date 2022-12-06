using AutoMapper;
using CommandsService.Application.Common.Exceptions;
using CommandsService.Application.Models.Platforms;
using CommandsService.Application.ViewModels.Platforms;
using CommandsService.Core.Entities;
using CommandsService.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Application.Handlers.Platforms
{
    public class PlatformsGetByIdHandler : IRequestHandler<PlatformsGetByIdQuery, PlatformsGetByIdVm>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PlatformsGetByIdHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PlatformsGetByIdVm> Handle(PlatformsGetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.Platforms.GetOneAsync(filter => filter.Id == request.Id && filter.IsDeleted == false, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Platform), request.Id);

            var vm = _mapper.Map<PlatformsGetByIdVm>(entity);

            return vm;
        }
    }
}
