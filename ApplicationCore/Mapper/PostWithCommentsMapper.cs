using System.Linq.Expressions;
using System.Linq;
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
            Status = post.Status,
            Title = post.Title,
            Comments = post.Comments.AsQueryable().Select(new CommentWithUserMapper().GetMapperExpression()).ToList()
        };
    }
}