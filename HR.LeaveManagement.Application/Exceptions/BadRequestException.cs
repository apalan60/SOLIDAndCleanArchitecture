using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException: Exception
{
    public BadRequestException(string message) : base(message)
    {

    }

    public BadRequestException(string message, ValidationResult validationResult) : this(message)
    {
        ValidationError = validationResult.ToDictionary();
    }

    public IDictionary<string, string[]>? ValidationError { get; set; }
}
