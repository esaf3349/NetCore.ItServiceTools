using CommandsService.Application.Models.Commands;
using FluentValidation;

namespace CommandsService.Application.Validators.Commands
{
    public class CommandsCreateCommandValidator : AbstractValidator<CommandsCreateCommand>
    {
        public CommandsCreateCommandValidator()
        {
            RuleFor(command => command.Subject).MaximumLength(100).NotEmpty();
            RuleFor(command => command.Expression).MaximumLength(100).NotEmpty();
            RuleFor(command => command.PlatformId).GreaterThan(0);
        }
    }
}
