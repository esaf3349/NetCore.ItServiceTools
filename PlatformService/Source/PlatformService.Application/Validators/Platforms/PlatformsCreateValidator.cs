using FluentValidation;
using PlatformService.Application.Models.Platforms;

namespace PlatformService.Application.Validators.Platforms
{
    public class PlatformsCreateValidator : AbstractValidator<PlatformsCreateCommand>
    {
        public PlatformsCreateValidator()
        {
            RuleFor(command => command.Name).MaximumLength(100).NotEmpty();
            RuleFor(command => command.Publisher).MaximumLength(100).NotEmpty();
            RuleFor(command => command.Cost).MaximumLength(100).NotEmpty();
        }
    }
}
