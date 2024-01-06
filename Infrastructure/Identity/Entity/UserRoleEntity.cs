using Domain.Model;
using Domain.Model.Interface;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Entity;

public class UserRoleEntity: IdentityRole<int>, IEntity
{
    public Guid Guid { get; set; }
}