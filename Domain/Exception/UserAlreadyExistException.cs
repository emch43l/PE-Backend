using Domain.Exception.Base;

namespace Domain.Exception;

public class UserAlreadyExistException : AlreadyExistException
{
    public UserAlreadyExistException(string message = "User already exist !") : base(message)
    {
    }
}