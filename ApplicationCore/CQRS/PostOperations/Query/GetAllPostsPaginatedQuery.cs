using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using Domain.ValueObject;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public record GetAllPostsPaginatedQuery : IQuery<GenericPaginatorResult<PostDto>>
{
    public Page Page { get; set; }
    
    public int ItemNumber { get; set; }

    public GetAllPostsPaginatedQuery(Page page, int pageSize = 10)
    {
        Page = page;
        ItemNumber = pageSize;
    }
    
}