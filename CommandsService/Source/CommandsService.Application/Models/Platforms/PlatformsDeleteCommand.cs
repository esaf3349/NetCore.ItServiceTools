using MediatR;

namespace CommandsService.Application.Models.Platforms
{
    public class PlatformsDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
