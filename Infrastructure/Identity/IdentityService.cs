using System.Security.Claims;
using ApplicationCore.Service;
using Domain.Exception;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<UserEntity> _manager;

    public IdentityService(UserManager<UserEntity> manager)
    {
        _manager = manager;
    }
    public async Task<IUser?> GetUserByEmailAsync(string email)
    {
        return await _manager.FindByEmailAsync(email);
    }

    public async Task<bool> CheckPasswordAsync(IUser user, string password)
    {
        return await _manager.CheckPasswordAsync((UserEntity)user, password);
    }

    public async Task<IUser> CreateUserAsync(string userName, string email, string password)
    {
        IUser? user = await GetUserByEmailAsync(email);
        if (user != null)
        {
            throw new UserAlreadyExistException($"User with this email already exist !");
        }

        UserEntity newUser = new UserEntity() { Email = email, UserName = userName };
        IdentityResult result = await _manager.CreateAsync(newUser, password);
        if (!result.Succeeded)
        {
            throw new IdentityException("Could not create user !");
        }

        return newUser;
    }

    public async Task<IUser> GetUserByClaimAsync(ClaimsPrincipal claimsPrincipal)
    {
        IUser? user = await _manager.GetUserAsync(claimsPrincipal);
        if (user == null)
            throw new UserNotFoundException();

        return user;
    }

    public async Task<IList<string>> GetUserRolesByEmailAsync(string email)
    {
        IUser? user = await GetUserByEmailAsync(email);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        
        IList<string> userRoles = await _manager.GetRolesAsync((UserEntity)user);
        return userRoles;
    }

}