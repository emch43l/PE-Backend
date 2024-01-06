using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using Domain.ValueObject;

namespace ApplicationCore.CQRS.CommentOperations.Query;

public class GetPostCommentsQuery : IQuery<IGenericPaginatorResult<CommentDto>>
{
    public Guid PostId { get; set; }
    public Page Page { get; set; }
    
    public GetPostCommentsQuery(Guid postId, Page page)
    {
        Page = page;
        PostId = postId;
    }
}