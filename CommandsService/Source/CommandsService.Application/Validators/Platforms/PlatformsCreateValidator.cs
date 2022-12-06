using CommandsService.Application.Models.Platforms;
using FluentValidation;

namespace CommandsService.Application.Validators.Platforms
{
    public class PlatformsCreateValidator : AbstractValidator<PlatformsCreateCommand>
    {
        public PlatformsCreateValidator()
        {
            RuleFor(command => command.Name).MaximumLength(100).NotEmpty();
            RuleFor(command => command.ExternalId).GreaterThan(0);
        }
    }
}
