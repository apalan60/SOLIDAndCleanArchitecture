using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException: Exception
{
    public BadRequestException(string message) : base(message)
    {

    }

    public BadRequestException(string message, ValidationResult validationResult) : this(message)
    {
        ValidationError = new();
        foreach (var error in validationResult.Errors) 
        {
            ValidationError.Add(error.ErrorMessage);  //ErrorMessage => which setting by WithMessage() 
        }
    }

    public List<string>? ValidationError { get; set; }
}
