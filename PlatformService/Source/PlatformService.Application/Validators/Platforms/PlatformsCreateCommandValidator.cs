using FluentValidation;
using PlatformService.Application.Models.Platforms;

namespace PlatformService.Application.Validators.Platforms
{
    public class PlatformsCreateCommandValidator : AbstractValidator<PlatformsCreateCommand>
    {
        public PlatformsCreateCommandValidator()
        {
            RuleFor(command => command.Name).MaximumLength(100).NotEmpty();
            RuleFor(command => command.Publisher).MaximumLength(100).NotEmpty();
            RuleFor(command => command.Cost).MaximumLength(100).NotEmpty();
        }
    }
}
