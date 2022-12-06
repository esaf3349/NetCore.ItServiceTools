using CommandsService.Application.Models.Commands;
using CommandsService.Application.Validators.Common;

namespace CommandsService.Application.Validators.Commands
{
    public class CommandsGetByIdValidator : GetByIdBaseValidator<CommandsGetByIdQuery>
    {
        public CommandsGetByIdValidator()
        {

        }
    }
}
