using CommandsService.Application.Models.Commands;
using CommandsService.Application.Validators.Common;

namespace CommandsService.Application.Validators.Commands
{
    public class CommandsGetAllQueryValidator : GetAllQueryAbstractValidator<CommandsGetAllQuery>
    {
        public CommandsGetAllQueryValidator()
        {

        }
    }
}
