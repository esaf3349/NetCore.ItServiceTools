using FluentValidation;
using PlatformService.Application.Models.Platforms;

namespace PlatformService.Application.Validators.Platforms
{
    public class PlatformsDeleteValidator : AbstractValidator<PlatformsDeleteCommand>
    {
        public PlatformsDeleteValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
