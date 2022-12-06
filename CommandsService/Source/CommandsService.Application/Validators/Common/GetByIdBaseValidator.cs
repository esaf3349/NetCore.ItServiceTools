using CommandsService.Application.Common.Interfaces;
using FluentValidation;

namespace CommandsService.Application.Validators.Common
{
    public abstract class GetByIdBaseValidator<TGetByIdQuery> : AbstractValidator<TGetByIdQuery> where TGetByIdQuery : IGetByIdQuery
    {
        public GetByIdBaseValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
