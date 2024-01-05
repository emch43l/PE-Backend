using Domain.Enum;
using Domain.Model.Generic;

namespace Infrastructure.Dev.Seed;

public class ReactionSeeder
{
    private int _numberOfReactions;

    private bool _randomize;

    private readonly Random _random;

    private readonly List<IUser> _users;

    private bool _interceptorInUse = true;
    
    public ReactionSeeder(int numberOfReactions, List<IUser> users, bool randomizeReactionCount = true)
    {
        _random = new Random();
        _numberOfReactions = numberOfReactions;
        _randomize = randomizeReactionCount;
        _users = users;
    }

    public void WithoutInterceptor()
    {
        _interceptorInUse = false;
    }

    public Comment SeedReactionsForComment(Comment comment)
    {
        int count = GetReactionCount();
        List<CommentReaction> result = GenerateCommentReactions(count, comment);
        if (!_interceptorInUse)
        {
            comment.ReactionCount = count;
        }
        comment.ReactionCount = count;
        comment.Reactions = result;
        return comment;
    }

    public Post SeedReactionsForPost(Post post)
    {
        int count = GetReactionCount();
        List<PostReaction> result = GeneratePostReactions(count, post);
        if (!_interceptorInUse)
        {
            post.ReactionCount = count;
        }
        post.Reactions = result;
        return post;
    }

    private List<PostReaction> GeneratePostReactions(int count, Post post)
    {
        return Enumerable.Range(0, count).Select(i => new PostReaction()
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
        return Enumerable.Range(0, count).Select(i => new CommentReaction()
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