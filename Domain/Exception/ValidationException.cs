using Domain.Exception.Base;

namespace Domain.Exception;

public class ValidationException : ExceptionBase
{
    public ValidationException(string message = "A validation error occured !") : base(message)
    {
    }
}