using Bogus;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;

namespace Infrastructure.Dev.Seed;

public class CommentSeeder
{
    private List<Comment> _rootCommentList;

    private List<Comment> _previousCommentList;

    private List<IUser> _users;

    public static int CommentId = 0;

    private ReactionSeeder? _reactionSeeder;

    private CommentRandomization _commentRandomization;

    private Random _random = new Random();

    private readonly Faker _faker = new Faker();

    public CommentSeeder(List<IUser> users)
    {
        _commentRandomization = CommentRandomization.None;
        _users = users;
        _rootCommentList = new List<Comment>();
        _previousCommentList = new List<Comment>();
    }
    
    public void AddReactionSeeder(ReactionSeeder seeder)
    {
        _reactionSeeder = seeder;
    }

    public void ClearSeeder()
    {
        _rootCommentList.Clear();
        _previousCommentList.Clear();
    }

    public void SetCommentRandomization(CommentRandomization randomization)
    {
        _commentRandomization = randomization;
    }
    
    public List<Comment> CreateComments(List<int> commentCountList, Post post)
    {
        commentCountList.ForEach(count => 
            CreateComments(_commentRandomization == CommentRandomization.None ? count : _random.Next(1,count+1) ,post)
            );

        post.CommentCount = _rootCommentList.Count;
        List<Comment> result = new List<Comment>(_rootCommentList);
        ClearSeeder();
        
        return result;
    }

    private CommentSeeder CreateComments(int commentCount, Post post)
    {
        if (_rootCommentList.Count == 0)
        {
            _rootCommentList = GenerateComments(commentCount, post, null);
            _previousCommentList = _rootCommentList;
            return this;
        }
        

        List<Comment> currentCommentList = _previousCommentList.Select(comment => 
            GenerateComments(commentCount, post, comment)).SelectMany(c => c).ToList();
        
        _rootCommentList.AddRange(currentCommentList);
        _previousCommentList = currentCommentList;
        
        return this;
    }

    private List<Comment> GenerateComments(int commentCount, Post post, Comment? comment)
    {
        return Enumerable
            .Range(1,_commentRandomization == CommentRandomization.Full ? _random.Next(1,commentCount+1) : commentCount )
            .Select(i => GenerateComment(post,i ,comment)).ToList();
    }
    
    private Comment GenerateComment(Post post, int count, Comment? parent)
    {
        Comment comment = new Comment();
        
        if (parent != null)
        {
            parent.RepliesCount = count;
        }
        
        comment.Id = ++CommentId;
        comment.User = RandomizeUser();
        comment.Parent = parent;
        comment.Post = post;
        comment.Content = _faker.Lorem.Paragraph(2);
        comment.DateCreated = DateTime.Now;
        
        if (_reactionSeeder != null)
        {
            comment = _reactionSeeder.SeedReactionsForComment(comment);
        }
        
        return comment;
    }

    private IUser RandomizeUser()
    {
        return _users[_random.Next(_users.Count)];
    }
}

public enum CommentRandomization
{
    None,
    Partial,
    Full
}