using AutoMapper;
using MediatR;
using PlatformService.Application.Models.Platforms;
using PlatformService.Application.ViewModels.Platforms;
using System.Threading.Tasks;
using System.Threading;
using PlatformService.Persistence.Interfaces;
using PlatformService.Application.Common.Exceptions;
using PlatformService.Core.Entities;

namespace PlatformService.Application.Handlers.Platforms
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
            var entity = await _uow.Platforms.GetOne(filter => filter.Id == request.Id && filter.IsDeleted == false);

            if (entity == null)
                throw new NotFoundException(nameof(Platform), request.Id);

            var vm = _mapper.Map<PlatformsGetByIdVm>(entity);

            return vm;
        }
    }
}
