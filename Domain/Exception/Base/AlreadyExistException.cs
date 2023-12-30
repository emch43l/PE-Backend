namespace Domain.Exception.Base;

public class AlreadyExistException : ExceptionBase
{
    public AlreadyExistException(string message = "This resource already exist !") : base(message)
    {
    }
}