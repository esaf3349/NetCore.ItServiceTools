using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandsService.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }

        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(ValidationFailure[] failures) : this()
        {
            var propertyNames = failures
                .Select(failure => failure.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(failure => failure.PropertyName == propertyName)
                    .Select(failure => failure.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }
    }
}
