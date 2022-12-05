using MediatR;

namespace CommandsService.Application.Models.Commands
{
    public class CommandsDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
