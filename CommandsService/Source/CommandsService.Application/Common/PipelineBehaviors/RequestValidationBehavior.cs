using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = CommandsService.Application.Common.Exceptions.ValidationException;

namespace CommandsService.Application.Common.PipelineBehaviors
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToArray();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
