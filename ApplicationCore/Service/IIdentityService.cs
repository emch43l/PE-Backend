using System.Security.Claims;
using Domain.Model;

namespace ApplicationCore.Service;

public interface IIdentityService
{
    Task<IUser> GetUserByClaimAsync(ClaimsPrincipal claimsPrincipal);
    
    Task<IList<string>> GetUserRolesByEmailAsync(string email);
    
    Task<IUser?> GetUserByEmailAsync(string email);
    
    Task<bool> CheckPasswordAsync(IUser user, string password);

    Task<IUser> CreateUserAsync(string userName, string email,  string password);

    Task<IUser?> GetUserByGuidAsync(Guid id);


}