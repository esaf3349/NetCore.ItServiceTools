using CommandsService.Application.Models.Commands;
using CommandsService.Application.Validators.Common;

namespace CommandsService.Application.Validators.Commands
{
    public class CommandsGetAllValidator : GetAllBaseValidator<CommandsGetAllQuery>
    {
        public CommandsGetAllValidator()
        {

        }
    }
}
