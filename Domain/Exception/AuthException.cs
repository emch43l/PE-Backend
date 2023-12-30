using Domain.Exception.Base;

namespace Domain.Exception;

public class AuthException : ExceptionBase
{
    public AuthException(string message = "An auth exception occured !") : base(message)
    {
    }
}