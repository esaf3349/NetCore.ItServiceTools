using MediatR;

namespace PlatformService.Application.Models.Platforms
{
    public class PlatformsCreateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Cost { get; set; }
    }
}
