using MediatR;

namespace CommandsService.Application.Models.Commands
{
    public class CommandsCreateCommand : IRequest<int>
    {
        public string Subject { get; set; }
        public string Expression { get; set; }
        public int PlatformId { get; set; }
    }
}
