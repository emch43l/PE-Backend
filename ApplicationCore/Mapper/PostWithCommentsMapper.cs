using System.Linq.Expressions;
using ApplicationCore.Dto;
using Domain.Model.Generic;

namespace ApplicationCore.Mapper;

public class PostWithCommentsMapper : AbstractMapper<Post,PostWithCommentsDto>
{
    public override Expression<Func<Post, PostWithCommentsDto>> GetMapperExpression()
    {
        return (Post post) => new PostWithCommentsDto()
        {
            Id = post.Guid,
            CommentCount = post.CommentCount,
            ReactionCount = post.ReactionCount,
            Date = post.Date,
            Description = post.Description,
            Status = StatusField.FromStatusEnum(post.Status),
            Title = post.Title,
            Comments = post.Comments.AsQueryable().Select(new CommentWithUserMapper().GetMapperExpression()).ToList()
        };
    }
}