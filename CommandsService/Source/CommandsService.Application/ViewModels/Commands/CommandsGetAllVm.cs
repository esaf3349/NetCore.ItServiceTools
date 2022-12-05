using CommandsService.Application.Dtos.Commands;

namespace CommandsService.Application.ViewModels.Commands
{
    public class CommandsGetAllVm
    {
        public CommandsGetAllDto[] Commands { get; set; }
    }
}
