namespace Domain.Exception;

public class PasswordException : IdentityException
{
    public PasswordException(string message = "Wrong password !") : base(message)
    {
        
    }
}