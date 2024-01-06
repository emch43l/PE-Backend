using Domain.Model;
using Domain.Model.Interface;
using Infrastructure.DB;
using Infrastructure.Dev.Seed;
using Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using File = Domain.Model.File;
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
            
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            

            UserEntity adminUser = await CreateUser(provider,"admin","admin@admin.com","zaq1@WSX");
            UserEntity normalUser = await CreateUser(provider,"user", "user@user.com","zaq1@WSX");
            UserEntity testUser = await CreateUser(provider, "test", "test@test.com", "zaq1@WSX");
            
            await AddUserToRole(provider, adminUser, "admin");
            await AddUserToRole(provider, adminUser, "user");
            await AddUserToRole(provider, normalUser, "user");
            await AddUserToRole(provider, testUser, "user");
            
            Random random = new Random();
            List<IUser> users = new List<IUser>();
            
            users.Add(adminUser);
            users.Add(normalUser);

            FileSeeder fileSeeder = new FileSeeder(users,"Resources/Images");
            
            CommentSeeder commentSeeder = new CommentSeeder(users);
            commentSeeder.SetCommentRandomization(CommentRandomization.Full);
            commentSeeder.AddReactionSeeder(new ReactionSeeder(50,users));
            
            PostSeeder postSeeder = new PostSeeder(users, 50);
            postSeeder.AddReactionSeeder(new ReactionSeeder(50, users));

            AlbumSeeder albumSeeder = new AlbumSeeder(users);
            
            List<File> files = fileSeeder.CreateFiles(100);
            List<Post> posts = postSeeder.CreatePosts();
            List<Comment> comments = postSeeder.PopulatePostsCommentsWithReactions(new List<int>([10, 7, 3]), commentSeeder);
            
            albumSeeder.AddFiles(files);
            albumSeeder.AddRatingSeeder(new AlbumRatingSeeder(users));

            List<Album> albums = albumSeeder.CreateAlbums(50);
            
            context.Database.OpenConnection();
            context.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Comments] ON;");
            
            context.AddRange(posts);
            context.AddRange(comments);
            context.AddRange(files);
            context.AddRange(albums);
            await context.SaveChangesAsync();
            
            context.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Comments] OFF;");

            
           
            // execute sql async zamyka odrazu polaczenie z baza danych
            // await context.Database.ExecuteSqlAsync($"SET IDENTITY_INSERT [dbo].[Comments] OFF;");
            // z tego powodu sesja w ktorej opcja SET IDENTITY_INSERT jest ustawiona na ON przestaje istniec po wyjsciu z tej funkcji

        }
    }

    private static async Task<UserEntity> CreateUser(IServiceProvider provider, string userName, string email, string password)
    {
        UserManager<UserEntity> manager = provider.GetRequiredService<UserManager<UserEntity>>();
        UserEntity? user = await manager.FindByNameAsync(userName);
        if (user == null)
        {
            user = new UserEntity();
            user.EmailConfirmed = true;
            user.UserName = userName;
            user.Email = email;

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