using ApplicationCore.Common.Interface;
using Domain.Enum;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;

namespace Infrastructure.Dev.Seed;

public class PostSeeder
{
    private List<IUser> _users;

    private int _numberOfPosts;

    private List<Post> _createdPosts;

    private Random _random = new Random();
    
    public PostSeeder(List<IUser> users, int numberOfPosts)
    {
        _createdPosts = new List<Post>();
        _users = users;
        _numberOfPosts = numberOfPosts;
    }

    public List<Post> CreatePosts()
    {
        _createdPosts = Enumerable.Range(0, _numberOfPosts).Select(p => CreatePost()).ToList();
        return _createdPosts;
    }
    
    private Post CreatePost()
    {
        Post entity = new Post();
        entity.Date = DateTime.Now;
        entity.Description = "Lorem ipsum description";
        entity.Title = "Lorem Title";
        entity.User = RandomizeUser();
        entity.Status = (StatusEnum)_random.Next(0, 3);
        return entity;
    }
    
    public List<Comment> PopulatePostsCommentsWithReactions(List<int> commentNumberList, CommentSeeder cSeeder, ReactionSeeder? rSeeder = null, bool randomizeCommentNumber = true)
    {
        List<Comment> result = new List<Comment>();
        
        foreach (Post post in _createdPosts)
        {
            Post loopedPost = post;
            ReactionSeeder reactionSeeder = new ReactionSeeder(50,_users);

            if (rSeeder != null)
            {
                loopedPost = reactionSeeder.SeedReactionsForPost(post);
            }
            
            commentNumberList.ForEach(number =>
            {
                cSeeder.CreateComments(randomizeCommentNumber ? _random.Next(1,number + 1) : number, RandomizeUser(), ref loopedPost);
            });
            
            result.AddRange(cSeeder.GetComments());
        }

        return result;
    }

    
    private IUser RandomizeUser()
    {
        return _users[_random.Next(_users.Count)];
    }
    
}