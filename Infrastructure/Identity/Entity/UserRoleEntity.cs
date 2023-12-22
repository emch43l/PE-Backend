using Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Entity;

public class UserRoleEntity: IdentityRole<int>, IEntity
{
    
}