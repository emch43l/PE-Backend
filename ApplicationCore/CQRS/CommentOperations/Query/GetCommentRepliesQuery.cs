using ApplicationCore.Dto;
using ApplicationCore.Pagination;

namespace ApplicationCore.CQRS.CommentOperations.Query;

public class GetCommentRepliesQuery : IQuery<IGenericPaginatorResult<CommentDto>>
{
    public Guid Id { get; set; }
    
    public int Page { get; set; }
    
    public GetCommentRepliesQuery(Guid id,int page)
    {
        Page = page;
        Id = id;
    }
}