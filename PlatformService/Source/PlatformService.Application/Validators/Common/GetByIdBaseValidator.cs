using FluentValidation;
using PlatformService.Application.Common.Interfaces;

namespace PlatformService.Application.Validators.Common
{
    public abstract class GetByIdBaseValidator<TGetByIdQuery> : AbstractValidator<TGetByIdQuery> where TGetByIdQuery : IGetByIdQuery
    {
        public GetByIdBaseValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
