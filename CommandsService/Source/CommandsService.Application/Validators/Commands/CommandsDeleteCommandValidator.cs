using CommandsService.Application.Models.Commands;
using FluentValidation;

namespace CommandsService.Application.Validators.Commands
{
    public class CommandsDeleteCommandValidator : AbstractValidator<CommandsDeleteCommand>
    {
        public CommandsDeleteCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
