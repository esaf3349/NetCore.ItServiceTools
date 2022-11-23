using MediatR;
using PlatformService.Application.ViewModels.Platforms;

namespace PlatformService.Application.Models.Platforms
{
    public class PlatformsGetAllQuery : IRequest<PlatformsGetAllVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
