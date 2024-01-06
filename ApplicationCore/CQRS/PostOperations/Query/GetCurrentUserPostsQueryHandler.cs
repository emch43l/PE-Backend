using System.Security.Claims;
using ApplicationCore.Common.Implementation.Specification.PostSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using ApplicationCore.Service;
using Domain.Common.Query;
using Domain.Common.Repository;
using Domain.Common.Repository.QueryRepository;
using Domain.Exception;
using Domain.Model;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetCurrentUserPostsQueryHandler : IQueryHandler<GetCurrentUserPostsQuery,IGenericPaginatorResult<PostWithCommentsDto>>
{
    private readonly IIdentityService _identityService;
    private readonly IGenericPaginator _paginator;
    private readonly IPostQueryRepository _postRepository;

    public GetCurrentUserPostsQueryHandler(IIdentityService identityService, IGenericPaginator paginator, IPostQueryRepository postRepository)
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

        IQueryManager<Post> queryManager = _postRepository.GetUserPostsWithCommentsQuery(user, 3).ApplySpecification(new PrivatePostSpecification());

        return await _paginator.SetPageSize(request.PageSize)
            .Paginate(queryManager.GetQuery(), new PostWithCommentsMapper(), request.Page);

    }
}