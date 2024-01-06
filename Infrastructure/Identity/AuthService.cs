using ApplicationCore.Service;
using Domain.Exception;
using Domain.Model;

namespace Infrastructure.Identity;

public class AuthService : IAuthService
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;

    public AuthService(IIdentityService identityService, ITokenService tokenService)
    {
        _identityService = identityService;
        _tokenService = tokenService;
    }

    public async Task<AuthResult> Login(string email, string password)
    {
        IUser? user = await _identityService.GetUserByEmailAsync(email);
        if (user == null)
            throw new UserNotFoundException("No user found for given email !");

        bool isPasswordOk = await _identityService.CheckPasswordAsync(user, password);
        if (!isPasswordOk)
            throw new PasswordException();

        string token = await _tokenService.CreateToken(user);

        return new AuthResult()
        {
            Token = token,
            UserId = user.Guid
        };
    }

    public async Task<AuthResult> Register(string userName, string email, string password)
    {
        IUser? user = await _identityService.CreateUserAsync(userName, email, password);
        string token = await _tokenService.CreateToken(user);

        return new AuthResult()
        {
            Token = token,
            UserId = user.Guid
        };
    }
}