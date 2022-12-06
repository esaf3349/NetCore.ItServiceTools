using CommandsService.Application.Common.Interfaces;
using FluentValidation;

namespace CommandsService.Application.Validators.Common
{
    public abstract class GetAllBaseValidator<TGetAllQuery> : AbstractValidator<TGetAllQuery> where TGetAllQuery : IGetAllQuery
    {
        public GetAllBaseValidator()
        {
            RuleFor(command => command.PageNumber).GreaterThan(0);
            RuleFor(command => command.PageSize).GreaterThan(0);
        }
    }
}
