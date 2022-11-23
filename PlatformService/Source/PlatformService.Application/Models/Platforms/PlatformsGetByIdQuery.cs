using MediatR;
using PlatformService.Application.ViewModels.Platforms;

namespace PlatformService.Application.Models.Platforms
{
    public class PlatformsGetByIdQuery : IRequest<PlatformsGetByIdVm>
    {
        public int Id { get; set; }
    }
}
