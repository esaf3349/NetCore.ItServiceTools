using CommandsService.Application.Models.Platforms;
using FluentValidation;

namespace CommandsService.Application.Validators.Platforms
{
    public class PlatformsDeleteValidator : AbstractValidator<PlatformsDeleteCommand>
    {
        public PlatformsDeleteValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
