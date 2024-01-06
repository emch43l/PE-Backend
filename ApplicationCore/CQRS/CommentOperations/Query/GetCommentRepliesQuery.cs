using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using Domain.ValueObject;

namespace ApplicationCore.CQRS.CommentOperations.Query;

public class GetCommentRepliesQuery : IQuery<IGenericPaginatorResult<CommentDto>>
{
    public Guid Id { get; set; }
    
    public Page Page { get; set; }
    
    public GetCommentRepliesQuery(Guid id,Page page)
    {
        Page = page;
        Id = id;
    }
}