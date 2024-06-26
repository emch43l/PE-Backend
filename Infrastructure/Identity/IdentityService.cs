﻿using System.Security.Claims;
using ApplicationCore.Common.Interface;
using ApplicationCore.Service;
using Domain.Exception;
using Domain.Model;
using Domain.Model.Interface;
using Infrastructure.Identity.Entity;
using Infrastructure.Identity.Extension;
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

    public async Task<IUser?> GetUserByGuidAsync(Guid id)
    {
        return await _manager.GetUserByGuidAsync(id);
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