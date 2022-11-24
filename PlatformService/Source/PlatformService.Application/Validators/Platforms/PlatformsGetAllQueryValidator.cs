using FluentValidation;
using PlatformService.Application.Models.Platforms;

namespace PlatformService.Application.Validators.Platforms
{
    public class PlatformsGetAllQueryValidator : AbstractValidator<PlatformsGetAllQuery>
    {
        public PlatformsGetAllQueryValidator()
        {
            RuleFor(command => command.PageNumber).GreaterThan(0);
            RuleFor(command => command.PageSize).GreaterThan(0);
        }
    }
}
