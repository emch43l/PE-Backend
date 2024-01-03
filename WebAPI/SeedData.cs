using ApplicationCore.Common.Interface;
using Domain.Enum;
using Domain.Model.Generic;
using Infrastructure.DB;
using Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            
            await AddUserToRole(provider, adminUser, "admin");
            await AddUserToRole(provider, adminUser, "user");
            await AddUserToRole(provider, normalUser, "user");
            
            Random random = new Random();
            
            List<Post> posts = Enumerable.Range(1, 50).Select(i => CreatePost(context, random.Next(2) == 0 ? adminUser : normalUser).Result).ToList();

            List<IUser> users = new List<IUser>();
            users.Add(adminUser);
            users.Add(normalUser);
            
            CommentSeeder commentSeeder = new CommentSeeder(users);
            
            context.Database.OpenConnection();
            context.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Comments] ON;");
            
            foreach (Post post in posts)
            {
                Post loopedPost = post;
                ReactionSeeder reactionSeeder = new ReactionSeeder(50,users);

                loopedPost = reactionSeeder.SeedReactionsForPost(post);
                
                commentSeeder
                    .CreateComments(random.Next(11), random.Next(2) == 0 ? adminUser : normalUser, ref loopedPost)
                    .CreateComments(random.Next(6), random.Next(2) == 0 ? adminUser : normalUser, ref loopedPost)
                    .CreateComments(random.Next(3), random.Next(2) == 0 ? adminUser : normalUser, ref loopedPost);
                
                context.AddRange(commentSeeder.GetComments(true));
                await context.SaveChangesAsync();
                
            }
            
            context.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Comments] OFF;");

            
           
            // execute sql async zamyka odrazu polaczenie z baza danych
            // await context.Database.ExecuteSqlAsync($"SET IDENTITY_INSERT [dbo].[Comments] OFF;");
            // z tego powodu sesja w ktorej opcja SET IDENTITY_INSERT jest ustawiona na ON przestaje istniec po wyjsciu z tej funkcji

        }
    }

    private static async Task<Post> CreatePost(IApplicationDbContext context, UserEntity user)
    {
        Post entity = new Post();
        entity.Date = DateTime.Now;
        entity.Description = "Lorem ipsum description";
        entity.Title = "Lorem Title";
        entity.User = user;
        entity.Status = (StatusEnum)(new Random()).Next(0, 3);
        await context.Posts.AddAsync(entity);
        return entity;
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

public class CommentSeeder
{
    private List<Comment> _rootCommentList;

    private List<Comment> _previousCommentList;

    private List<IUser> _users;

    public static int CommentId = 0;

    private bool _seedReactions;

    public CommentSeeder(List<IUser> users, bool seedReactions = true)
    {
        _seedReactions = seedReactions;
        _users = users;
        _rootCommentList = new List<Comment>();
        _previousCommentList = new List<Comment>();
    }
    
    public List<Comment> GetComments(bool clearSeeder = true)
    {
        List<Comment> result = new List<Comment>(_rootCommentList);
        if (clearSeeder == true)
        {
            ClearSeeder();
        }
        
        return result;
    }

    public void ClearSeeder()
    {
        _rootCommentList.Clear();
        _previousCommentList.Clear();
    }

    public CommentSeeder CreateComments(int commentCount, UserEntity user, ref Post post)
    {
        Post currentPost = post;
        
        if (_rootCommentList.Count == 0)
        {
            _rootCommentList = GenerateComments(commentCount, user, currentPost, null);
            _previousCommentList = _rootCommentList;
            return this;
        }
        

        List<Comment> currentCommentList = _previousCommentList.Select(comment => 
            GenerateComments(commentCount, user, currentPost, comment))
            .SelectMany(c => c).ToList();
        
        _rootCommentList.AddRange(currentCommentList);
        _previousCommentList = currentCommentList;

        post.CommentCount = _rootCommentList.Count;
        
        return this;
    }

    private List<Comment> GenerateComments(int commentCount, UserEntity user, Post post, Comment? comment)
    {
        return Enumerable.Range(0, commentCount).Select(i => GenerateComment(post, user, comment)).ToList();
    }
    
    private Comment GenerateComment(Post post, UserEntity user, Comment? parent)
    {
        ReactionSeeder reactionSeeder = new ReactionSeeder(20,_users);
        
        Comment comment = new Comment();
        comment.Id = ++CommentId;
        comment.User = user;
        comment.Parent = parent;
        comment.Post = post;
        comment.Content = "Lorem ipsum description";
        comment.DateCreated = DateTime.Now;
        if (_seedReactions)
        {
            comment = reactionSeeder.SeedReactionsForComment(comment);
        }
        return comment;
    }
}

public class ReactionSeeder
{
    private int _numberOfReactions;

    private bool _randomize;

    private readonly Random _random;

    private readonly List<IUser> _users;
    
    public ReactionSeeder(int numberOfReactions, List<IUser> users, bool randomizeReactionCount = true)
    {
        _random = new Random();
        _numberOfReactions = numberOfReactions;
        _randomize = randomizeReactionCount;
        _users = users;
    }

    public Comment SeedReactionsForComment(Comment comment)
    {
        int count = GetReactionCount();
        List<CommentReaction> result = GenerateCommentReactions(count, comment);
        comment.ReactionCount = count;
        comment.Reactions = result;
        return comment;
    }

    public Post SeedReactionsForPost(Post post)
    {
        int count = GetReactionCount();
        List<PostReaction> result = GeneratePostReactions(count, post);
        post.ReactionCount = count;
        post.Reactions = result;
        return post;
    }

    private List<PostReaction> GeneratePostReactions(int count, Post post)
    {
        return Enumerable.Range(1, count).Select(i => new PostReaction()
            {
                Post = post,
                Date = DateTime.Now,
                ReactionType = RandomizeReactionType(),
                User = RandomizeUser()
            }
        ).ToList();
    }

    private List<CommentReaction> GenerateCommentReactions(int count, Comment comment)
    {
        return Enumerable.Range(1, count).Select(i => new CommentReaction()
            {
                Comment = comment,
                Date = DateTime.Now,
                ReactionType = RandomizeReactionType(),
                User = RandomizeUser()
            }
        ).ToList();
    }

    private ReactionTypeEnum RandomizeReactionType()
    {
        return (ReactionTypeEnum)_random.Next(6);
    }

    private IUser RandomizeUser()
    {
        return _users[_random.Next(_users.Count)];
    }

    private int GetReactionCount()
    {
        return _randomize ? _random.Next(_numberOfReactions + 1) : _numberOfReactions;
    }
}