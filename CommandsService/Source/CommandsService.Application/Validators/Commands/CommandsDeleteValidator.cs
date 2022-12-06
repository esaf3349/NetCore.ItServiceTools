using CommandsService.Application.Models.Commands;
using FluentValidation;

namespace CommandsService.Application.Validators.Commands
{
    public class CommandsDeleteValidator : AbstractValidator<CommandsDeleteCommand>
    {
        public CommandsDeleteValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
