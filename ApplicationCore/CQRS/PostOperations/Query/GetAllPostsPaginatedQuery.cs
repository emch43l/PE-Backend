using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public record GetAllPostsPaginatedQuery : IQuery<GenericPaginatorResult<PostDto>>
{
    public int PageNumber { get; set; }
    
    public int ItemsPerPage { get; set; }

    public GetAllPostsPaginatedQuery(int page = 1, int pageSize = 10)
    {
        this.PageNumber = page;
        this.ItemsPerPage = pageSize;
    }
    
}