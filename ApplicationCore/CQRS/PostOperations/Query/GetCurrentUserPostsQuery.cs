using System.Security.Claims;
using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetCurrentUserPostsQuery : IQuery<IGenericPaginatorResult<PostWithCommentsDto>>
{
    public int Page { get; set; }
    
    public int PageSize { get; set; }
    
    public ClaimsPrincipal CurrentUser { get; set; }
    
    public GetCurrentUserPostsQuery(ClaimsPrincipal currentUser, int page, int pageSize)
    {
        CurrentUser = currentUser;
        Page = page;
        PageSize = pageSize;
    }
}