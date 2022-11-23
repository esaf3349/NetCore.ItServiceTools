using MediatR;

namespace PlatformService.Application.Models.Platforms
{
    public class PlatformsDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
