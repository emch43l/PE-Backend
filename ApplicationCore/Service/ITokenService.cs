using Domain.Model.Generic;

namespace ApplicationCore.Service;

public interface ITokenService
{
    Task<string> CreateToken(IUser user);
}