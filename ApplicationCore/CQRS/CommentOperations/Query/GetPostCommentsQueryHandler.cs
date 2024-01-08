using ApplicationCore.Common.Implementation.Specification.CommentSpecification;
using ApplicationCore.Common.Implementation.Specification.PostSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using Domain.Common.Repository;
using Domain.Exception;
using Domain.Model;

namespace ApplicationCore.CQRS.CommentOperations.Query;

public class GetPostCommentsQueryHandler : IQueryHandler<GetPostCommentsQuery,IGenericPaginatorResult<CommentDto>>
{
    private const int CommentNumberPerPage = 5;
    
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    private readonly IPaginator _paginator;
    public GetPostCommentsQueryHandler(ICommentRepository repository,
        IPostRepository postRepository,
        IPaginator paginator)
    {
        _postRepository = postRepository;
        _paginator = paginator;
        _commentRepository = repository;
    }

    public async Task<IGenericPaginatorResult<CommentDto>> Handle(GetPostCommentsQuery query, CancellationToken cancellationToken)
    {
        Post? post = await _postRepository.FindBySpecificationAsync(new GetPublicPostWithUserSpecification(query.PostId));
        
        if (post == null)
        {
            throw new PostNotFoundException();
        }

        IGenericPaginatorResult<CommentDto> result = await _paginator
            .SetPageSize(CommentNumberPerPage)
            .Paginate(
                _commentRepository
                    .GetQueryManager()
                    .ApplySpecification(new GetPostCommentsSpecification(post.Id)),
                new CommentWithUserMapper(), 
                query.Page.Value
                );

        return result;
    }
}