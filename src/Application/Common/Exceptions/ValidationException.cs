using FluentValidation.Results;

namespace Projectify.Application.Common.Exceptions;

public class ValidationException()
    : Exception("One or more validation errors occurred.")
{
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(x => x.PropertyName, x => x.ErrorMessage)
            .ToDictionary(
                group => group.Key,
                group => group.ToArray());
    }
    
    public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
}