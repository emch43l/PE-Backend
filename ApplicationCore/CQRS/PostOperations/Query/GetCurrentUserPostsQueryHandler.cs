using System.Security.Claims;
using ApplicationCore.Common.Implementation.Specification.PostSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using ApplicationCore.Service;
using Domain.Common.Repository;
using Domain.Exception;
using Domain.Model.Interface;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetCurrentUserPostsQueryHandler : IQueryHandler<GetCurrentUserPostsQuery,IGenericPaginatorResult<PostWithCommentsDto>>
{
    private readonly IIdentityService _identityService;
    private readonly IPaginator _paginator;
    private readonly IPostRepository _postRepository;

    public GetCurrentUserPostsQueryHandler(IIdentityService identityService, IPaginator paginator, IPostRepository postRepository)
    {
        _identityService = identityService;
        _paginator = paginator;
        _postRepository = postRepository;
    }

    public async Task<IGenericPaginatorResult<PostWithCommentsDto>> Handle(GetCurrentUserPostsQuery request, CancellationToken cancellationToken)
    {
        string? currentUser = request.CurrentUser.FindFirst(ClaimTypes.Email)?.Value;
        if (currentUser == null)
            throw new UnauthorizedException();
        
        IUser? user = await _identityService.GetUserByEmailAsync(currentUser);
        if (user == null)
            throw new UserNotFoundException();
        
        return await _paginator
            .SetPageSize(request.PageSize.Value)
            .Paginate(_postRepository
                .GetQueryManager()
                .ApplySpecification(new GetPrivateUserPostsWithCommentsSpecification(user.Id)), 
                new PostWithCommentsMapper(), 
                request.Page.Value
                );

    }
}