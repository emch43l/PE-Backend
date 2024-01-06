using Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity.Extension;

public static class UserManagerExtensions
{
    public static async Task<UserEntity?> GetUserByGuidAsync(this UserManager<UserEntity> manager, Guid id)
    {
        return await manager.Users.FirstOrDefaultAsync(u => u.Guid == id);
    }
}