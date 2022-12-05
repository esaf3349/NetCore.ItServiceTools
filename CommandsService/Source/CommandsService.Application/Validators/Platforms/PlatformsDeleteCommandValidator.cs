using CommandsService.Application.Models.Platforms;
using FluentValidation;

namespace CommandsService.Application.Validators.Platforms
{
    public class PlatformsDeleteCommandValidator : AbstractValidator<PlatformsDeleteCommand>
    {
        public PlatformsDeleteCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
