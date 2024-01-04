using Domain.Enum;
using Domain.Model.Generic;

namespace Infrastructure.Dev.Seed;

public class PostSeeder
{
    private List<IUser> _users;

    private readonly int _numberOfPosts;

    private List<Post> _createdPosts;

    private readonly Random _random = new Random();

    private ReactionSeeder? _reactionSeeder;
    
    
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
    
    public List<Comment> PopulatePostsCommentsWithReactions(List<int> commentNumberList, CommentSeeder commentSeeder, bool randomizeCommentNumber = true)
    {
        List<Comment> result = new List<Comment>();

        foreach (Post post in _createdPosts)
        {
            ReactionSeeder reactionSeeder = new ReactionSeeder(50,_users);

            if (_reactionSeeder != null)
            {
                reactionSeeder.SeedReactionsForPost(post);
            }

            List<Comment> comments = commentSeeder.CreateComments(commentNumberList, post);
            
            result.AddRange(comments);
        }

        return result;
    }

    public void AddReactionSeeder(ReactionSeeder reactionSeeder)
    {
        _reactionSeeder = reactionSeeder;
    }
    
    
    private IUser RandomizeUser()
    {
        return _users[_random.Next(_users.Count)];
    }
    
}