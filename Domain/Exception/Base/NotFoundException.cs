namespace Domain.Exception.Base;

public class NotFoundException : ExceptionBase
{
    public NotFoundException(string message = "Not found !") : base(message)
    {
        
    }
}