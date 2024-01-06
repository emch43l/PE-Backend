namespace ApplicationCore.Service;

public interface IAuthService
{
    Task<AuthResult> Login(string email, string password);

    Task<AuthResult> Register(string userName, string email, string password);
}