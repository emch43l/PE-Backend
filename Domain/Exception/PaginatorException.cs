using Domain.Exception.Base;

namespace Domain.Exception;

public class PaginatorException : ExceptionBase
{
    public PaginatorException(string message = "An error occured !") : base(message)
    {
        
    }
}