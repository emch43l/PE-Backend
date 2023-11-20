using ApplicationCore.Common.Implementation.EntityImplementation;
using Domain.Enum;
using Infrastructure.DB;
using Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;
using UserEntity = Infrastructure.Identity.Entity.UserEntity;


namespace WebAPI;

public static class SeedData
{
    public static async void Seed(this IApplicationBuilder app)
    {
        using (IServiceScope scope = app.ApplicationServices.CreateScope())
        {

            IServiceProvider provider = scope.ServiceProvider;
            ApplicationDbContext context = provider.GetRequiredService<ApplicationDbContext>();

            UserEntity user = await CreateUser(provider,"SampleUser","zaq1@WSX");
            await AddUserToRole(provider, user, "admin");

            PostEntity genericPostEntity = new PostEntity();
            genericPostEntity.Date = DateTime.Now;
            genericPostEntity.Description = "Lorem ipsum description";
            genericPostEntity.Title = "Lorem Title";
            genericPostEntity.GenericUser = user;
            genericPostEntity.Status = StatusEnum.Visible;

            context.Posts.Add(genericPostEntity);
            await context.SaveChangesAsync();
        }
    }

    private static async Task<UserEntity> CreateUser(IServiceProvider provider,  string userName, string password)
    {
        UserManager<UserEntity> manager = provider.GetRequiredService<UserManager<UserEntity>>();
        UserEntity? user = await manager.FindByNameAsync(userName);
        if (user == null)
        {
            user = new UserEntity();
            user.EmailConfirmed = true;
            user.UserName = userName;

            IdentityResult result = await manager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception("Something went wrong !");
            }
        }

        return user;
    }

    private static async Task AddUserToRole(IServiceProvider provider, UserEntity user, string roleName)
    {
        RoleManager<UserRoleEntity> rManager = provider.GetRequiredService<RoleManager<UserRoleEntity>>();
        UserManager<UserEntity> uManager = provider.GetRequiredService<UserManager<UserEntity>>();
        
        bool isRoleExists = await rManager.RoleExistsAsync(roleName);
        
        if(!isRoleExists)
        {
            UserRoleEntity role = new UserRoleEntity();
            role.Name = roleName;
            
            await rManager.CreateAsync(role);
            await uManager.AddToRoleAsync(user, roleName);
        }
        else
        {
            await uManager.AddToRoleAsync(user, roleName);
        }
    }
}