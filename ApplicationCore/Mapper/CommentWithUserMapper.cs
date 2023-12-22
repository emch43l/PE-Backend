using System.Linq.Expressions;
using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Dto;
using Domain.Model.Generic;

namespace ApplicationCore.Mapper;

public class CommentWithUserMapper : IMapper<GenericCommentEntity<int>,CommentDto>
{
    public CommentDto GetMappedResult()
    {
        throw new NotImplementedException();
    }

    public Expression<Func<GenericCommentEntity<int>, CommentDto>> GetMapperExpression()
    {
        return (GenericCommentEntity<int> comment) => new CommentDto()
        {
            Content = comment.Content,
            DateCreated = comment.DateCreated,
            ReactionCount = comment.ReactionCount,
            UserName = comment.User.UserName
        };
    }
}