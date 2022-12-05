using CommandsService.Application.Models.Commands;
using CommandsService.Application.Validators.Common;

namespace CommandsService.Application.Validators.Commands
{
    public class CommandsGetByIdQueryValidator : GetByIdQueryAbstractValidator<CommandsGetByIdQuery>
    {
        public CommandsGetByIdQueryValidator()
        {

        }
    }
}
