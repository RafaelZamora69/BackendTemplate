namespace Application.Abstractions.Exceptions;

public class ValidationException(List<ValidationError> errors) : Exception
{
    public List<ValidationError> Errors { get; set; } = errors;
}