using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using Domain.Model.Generic;

namespace ApplicationCore.CQRS.CommentOperations.Query;

public class GetPostCommentsQuery : IQuery<IGenericPaginatorResult<CommentDto>>
{
    public Guid PostId { get; set; }
    public int Page { get; set; }
    
    public GetPostCommentsQuery(Guid postId, int page = 1)
    {
        Page = page;
        PostId = postId;
    }
}