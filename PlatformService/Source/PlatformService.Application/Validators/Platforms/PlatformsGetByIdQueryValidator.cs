using FluentValidation;
using PlatformService.Application.Models.Platforms;

namespace PlatformService.Application.Validators.Platforms
{
    public class PlatformsGetByIdQueryValidator : AbstractValidator<PlatformsGetByIdQuery>
    {
        public PlatformsGetByIdQueryValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
