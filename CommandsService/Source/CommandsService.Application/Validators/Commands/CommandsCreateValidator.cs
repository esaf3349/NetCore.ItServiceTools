using CommandsService.Application.Models.Commands;
using FluentValidation;

namespace CommandsService.Application.Validators.Commands
{
    public class CommandsCreateValidator : AbstractValidator<CommandsCreateCommand>
    {
        public CommandsCreateValidator()
        {
            RuleFor(command => command.Subject).MaximumLength(100).NotEmpty();
            RuleFor(command => command.Expression).MaximumLength(100).NotEmpty();
            RuleFor(command => command.PlatformId).GreaterThan(0);
        }
    }
}
