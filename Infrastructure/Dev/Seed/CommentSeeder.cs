using Domain.Model.Generic;
using Infrastructure.Identity.Entity;

namespace Infrastructure.Dev.Seed;

public class CommentSeeder
{
    private List<Comment> _rootCommentList;

    private List<Comment> _previousCommentList;

    private List<IUser> _users;

    public static int CommentId = 0;

    private bool _seedReactions;

    private ReactionSeeder? _reactionSeeder;

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

    public CommentSeeder AddReactionSeeder(ReactionSeeder seeder)
    {
        _reactionSeeder = seeder;
        return this;
    }

    public void ClearSeeder()
    {
        _rootCommentList.Clear();
        _previousCommentList.Clear();
    }

    public CommentSeeder CreateComments(int commentCount, IUser user, ref Post post)
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

    private List<Comment> GenerateComments(int commentCount, IUser user, Post post, Comment? comment)
    {
        return Enumerable.Range(1, commentCount).Select(i => GenerateComment(post, user ,i ,comment)).ToList();
    }
    
    private Comment GenerateComment(Post post, IUser user, int count, Comment? parent)
    {
        Comment comment = new Comment();
        if (parent != null)
        {
            parent.RepliesCount = count;
        }
        comment.Id = ++CommentId;
        comment.User = user;
        comment.Parent = parent;
        comment.Post = post;
        comment.Content = "Lorem ipsum description";
        comment.DateCreated = DateTime.Now;
        if (_seedReactions && _reactionSeeder != null)
        {
            comment = _reactionSeeder.SeedReactionsForComment(comment);
        }
        return comment;
    }
}