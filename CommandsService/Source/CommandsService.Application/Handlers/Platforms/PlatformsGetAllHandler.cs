using AutoMapper;
using CommandsService.Application.Dtos.Platforms;
using CommandsService.Application.Models.Platforms;
using CommandsService.Application.ViewModels.Platforms;
using CommandsService.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Application.Handlers.Platforms
{
    public class PlatformsGetAllHandler : IRequestHandler<PlatformsGetAllQuery, PlatformsGetAllVm>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PlatformsGetAllHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PlatformsGetAllVm> Handle(PlatformsGetAllQuery request, CancellationToken cancellationToken)
        {
            if (request.PageNumber < 1) request.PageNumber = 1;
            if (request.PageSize < 1) request.PageSize = 20;

            var platforms = await _uow.Platforms.GetManyAsync(filter => filter.IsDeleted == false, request.PageNumber, request.PageSize, cancellationToken);
            var dtos = _mapper.Map<IEnumerable<PlatformsGetAllDto>>(platforms).ToArray();
            var vm = new PlatformsGetAllVm
            {
                Platforms = dtos
            };

            return vm;
        }
    }
}
