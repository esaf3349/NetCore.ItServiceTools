using AutoMapper;
using Grpc.Core;
using MediatR;
using PlatformService.Application.Models.Platforms;
using PlatformService.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Implementation.Services.Grpc
{
    public class PlatformsSeedDataService : PlatformsGrpcService.PlatformsGrpcServiceBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PlatformsSeedDataService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override Task<PlatformsGetAllVm> PlatformsGetAll(PlatformsGetAllRequest request, ServerCallContext context)
        {
            var response = new PlatformsGetAllVm();

            var vm = _mediator.Send(new PlatformsGetAllQuery { PageNumber = 1, PageSize = 100 });

            foreach (var platform in vm.Result.Platforms)
            {
                response.Platforms.Add(_mapper.Map<PlatformsGetAllDto>(platform));
            }

            return Task.FromResult(response);
        }
    }
}
