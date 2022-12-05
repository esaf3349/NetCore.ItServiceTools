using CommandsService.Application.Common.Interfaces;
using FluentValidation;

namespace CommandsService.Application.Validators.Common
{
    public abstract class GetAllQueryAbstractValidator<TGetAllQuery> : AbstractValidator<TGetAllQuery> where TGetAllQuery : IGetAllQuery
    {
        public GetAllQueryAbstractValidator()
        {
            RuleFor(command => command.PageNumber).GreaterThan(0);
            RuleFor(command => command.PageSize).GreaterThan(0);
        }
    }
}
