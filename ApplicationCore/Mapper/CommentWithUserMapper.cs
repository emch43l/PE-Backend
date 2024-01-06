using System.Linq.Expressions;
using ApplicationCore.Dto;
using ApplicationCore.Mapper.Base;
using Domain.Model;

namespace ApplicationCore.Mapper;

public class CommentWithUserMapper : AbstractMapper<Comment,CommentDto>
{
    public override Expression<Func<Comment, CommentDto>> GetMapperExpression()
    {
        return (Comment comment) => new CommentDto()
        {
            Id = comment.Guid,
            Content = comment.Content,
            DateCreated = comment.DateCreated,
            RepliesCount = comment.RepliesCount,
            ReactionCount = comment.ReactionCount,
            UserName = comment.User.UserName
        };
    }
}