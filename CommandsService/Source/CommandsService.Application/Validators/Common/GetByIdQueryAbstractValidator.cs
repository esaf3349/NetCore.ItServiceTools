using CommandsService.Application.Common.Interfaces;
using FluentValidation;

namespace CommandsService.Application.Validators.Common
{
    public abstract class GetByIdQueryAbstractValidator<TGetByIdQuery> : AbstractValidator<TGetByIdQuery> where TGetByIdQuery : IGetByIdQuery
    {
        public GetByIdQueryAbstractValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
