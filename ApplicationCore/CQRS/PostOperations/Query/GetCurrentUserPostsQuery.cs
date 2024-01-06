using System.Security.Claims;
using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using Domain.ValueObject;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetCurrentUserPostsQuery : IQuery<IGenericPaginatorResult<PostWithCommentsDto>>
{
    public Page Page { get; set; }
    
    public ItemNumber PageSize { get; set; }
    
    public ClaimsPrincipal CurrentUser { get; set; }
    
    public GetCurrentUserPostsQuery(ClaimsPrincipal currentUser, Page page, ItemNumber pageSize)
    {
        CurrentUser = currentUser;
        Page = page;
        PageSize = pageSize;
    }
}