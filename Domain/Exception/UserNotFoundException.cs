using Domain.Exception.Base;

namespace Domain.Exception;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string message = "User not found !") : base(message)
    {
    }
}