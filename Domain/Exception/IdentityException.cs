using Domain.Exception.Base;

namespace Domain.Exception;

public class IdentityException : ExceptionBase
{
    public IdentityException(string message = "An identity exception occured !") : base(message)
    {
    }
}