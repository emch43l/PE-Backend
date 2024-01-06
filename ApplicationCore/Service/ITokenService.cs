using Domain.Model;
using Domain.Model.Interface;

namespace ApplicationCore.Service;

public interface ITokenService
{
    Task<string> CreateToken(IUser user);
}