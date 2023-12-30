using Domain.Exception.Base;

namespace Domain.Exception;

public class UnauthorizedException : ExceptionBase
{
    public UnauthorizedException(string message = "Unauthorized !") : base(message)
    {
    }
}