using ApplicationCore.Common.Implementation.EntityImplementation;
using ApplicationCore.Pagination;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public record GetAllPostsPaginatedQuery : IRequest<GenericPaginatorResult<PostEntity>>
{
    public int PageNumber { get; set; }
    
    public int ItemsPerPage { get; set; }

    public GetAllPostsPaginatedQuery(int Page = 1, int PageSize = 10)
    {
        this.PageNumber = Page;
        this.ItemsPerPage = PageSize;
    }
    
}