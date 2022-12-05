using CommandsService.Application.Models.Platforms;
using FluentValidation;

namespace CommandsService.Application.Validators.Platforms
{
    public class PlatformsCreateCommandValidator : AbstractValidator<PlatformsCreateCommand>
    {
        public PlatformsCreateCommandValidator()
        {
            RuleFor(command => command.Name).MaximumLength(100).NotEmpty();
            RuleFor(command => command.ExternalId).GreaterThan(0);
        }
    }
}
