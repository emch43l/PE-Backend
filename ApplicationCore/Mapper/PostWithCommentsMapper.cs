using System.Linq.Expressions;
using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Dto;
using Domain.Model.Generic;

namespace ApplicationCore.Mapper;

public class PostWithCommentsMapper : IMapper<PostEntity,PostWithCommentsDto>
{
    public PostWithCommentsDto GetMappedResult()
    {
        throw new NotImplementedException();
    }

    public Func<GenericCommentEntity<int>, CommentDto> GetMapperExpression()
    {
        return (PostEntity post) => new PostWithCommentsDto()
        {
            CommentCount = post.CommentCount,
            ReactionCount = post.ReactionCount,
            Date = post.Date,
            Description = post.Description,
            Status = post.Status,
            Title = post.Title,
            Comments = post.Comments.Select(new CommentWithUserMapper().GetMapperExpression())
        }
    }
}