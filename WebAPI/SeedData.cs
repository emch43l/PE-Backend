using ApplicationCore.Common.Interface;
using Domain.Enum;
using Domain.Model.Generic;
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
            Post post = await CreatePost(context,user);
            await CreateComments(context, user, post);
            await context.SaveChangesAsync();
        }
    }

    private static async Task<Post> CreatePost(IApplicationDbContext context, UserEntity user)
    {
        Post genericPostEntity = new Post();
        genericPostEntity.Date = DateTime.Now;
        genericPostEntity.Description = "Lorem ipsum description";
        genericPostEntity.Title = "Lorem Title";
        genericPostEntity.User = user;
        genericPostEntity.Status = StatusEnum.Visible;
        await context.Posts.AddAsync(genericPostEntity);
        return genericPostEntity;
    }

    private static async Task<List<Comment>> CreateComments(IApplicationDbContext context, UserEntity user,
        Post post)
    {
        const int commentCount = 20;
        post.CommentCount = 20;
        
        return await Task.Run(() => Enumerable.Range(1, commentCount).Select( i =>
        {
            Comment comment = new Comment();
            comment.User = user;
            comment.Content = new Random().Next(1,2) == 1 ? "Lorem" : "Ipsum";
            comment.Post = post;
            comment.DateCreated = DateTime.Now;
            comment.File = null;
            context.Comments.Add(comment);
            return comment;
        }).ToList());
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