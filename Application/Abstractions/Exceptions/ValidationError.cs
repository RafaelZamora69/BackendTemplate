namespace Application.Abstractions.Exceptions;

public sealed class ValidationError
{

    public ValidationError(string propertyName, string message)
    {
        PropertyName = propertyName;
        Message = message;
    }
    
    public string PropertyName { get; set; }
    public string Message { get; set; }
}