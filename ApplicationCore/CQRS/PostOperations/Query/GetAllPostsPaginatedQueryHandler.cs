using ApplicationCore.Common.Implementation.Specification.PostSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using Domain.Common.Repository;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetAllPostsPaginatedQueryHandler: IQueryHandler<GetAllPostsPaginatedQuery,GenericPaginatorResult<PostDto>>
{
    private readonly IPaginator _paginator;
    private readonly IPostRepository _postRepository;

    public GetAllPostsPaginatedQueryHandler(
        IPostRepository postRepository, IPaginator paginator)
    {
        _postRepository = postRepository;
        _paginator = paginator;
    }

    public async Task<GenericPaginatorResult<PostDto>> Handle(GetAllPostsPaginatedQuery request,
        CancellationToken cancellationToken)
    {
        
        GenericPaginatorResult<PostDto> result = 
            await _paginator
                .SetPageSize(request.ItemNumber)
                .Paginate(
                    _postRepository
                        .GetQueryManager()
                        .ApplySpecification(new GetPublicPostsWithUserAndFirstCommentSpecification()), 
                    new PostWithUserAndSingleCommentMapper(), 
                    request.Page.Value
                    );
        
        return result;

    }
}