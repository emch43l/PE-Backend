using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using MediatR;

namespace ApplicationCore.CQRS.Comment.Query;

public class GetPostCommentsQuery : IRequest<IGenericPaginatorResult<CommentDto>>
{
    public Guid PostId { get; set; }
    public int Page { get; set; }
    
    public GetPostCommentsQuery(Guid postId, int page = 1)
    {
        Page = page;
        PostId = postId;
    }
}