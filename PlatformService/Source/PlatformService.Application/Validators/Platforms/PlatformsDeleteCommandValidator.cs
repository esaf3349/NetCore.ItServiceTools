using FluentValidation;
using PlatformService.Application.Models.Platforms;

namespace PlatformService.Application.Validators.Platforms
{
    public class PlatformsDeleteCommandValidator : AbstractValidator<PlatformsDeleteCommand>
    {
        public PlatformsDeleteCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
