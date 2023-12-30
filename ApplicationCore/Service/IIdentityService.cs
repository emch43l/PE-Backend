using Domain.Model.Generic;

namespace ApplicationCore.Service;

public interface IIdentityService
{
    Task<IList<string>> GetUserRolesByEmail(string email);
    Task<IUser?> GetUserByEmailAsync(string email);
    
    Task<bool> CheckPasswordAsync(IUser user, string password);

    Task<IUser> CreateUserAsync(string userName, string email,  string password);
    
}