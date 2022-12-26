using MediatR;

namespace CommandsService.Application.Models.Platforms
{
    public class PlatformsCreateCommand : IRequest<int>
    {
        public int ExternalId { get; set; }
        public string Name { get; set; }
    }
}
