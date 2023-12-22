using System.Linq.Expressions;
using ApplicationCore.Dto;
using Domain.Model.Generic;

namespace ApplicationCore.Mapper;

public class CommentWithUserMapper : AbstractMapper<Comment,CommentDto>
{
    public override Expression<Func<Comment, CommentDto>> GetMapperExpression()
    {
        return (Comment comment) => new CommentDto()
        {
            Content = comment.Content,
            DateCreated = comment.DateCreated,
            ReactionCount = comment.ReactionCount,
            UserName = comment.User.UserName
        };
    }
}