using Domain.Model;

namespace ApplicationCore.Service;

public interface ITokenService
{
    Task<string> CreateToken(IUser user);
}