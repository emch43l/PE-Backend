using ApplicationCore.Common.Implementation.Specification.CommentSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using Domain.Common.Repository;
using Domain.Common.Specification;
using Domain.Exception.Base;
using Domain.Model;

namespace ApplicationCore.CQRS.CommentOperations.Query;

public class GetCommentRepliesQueryHandler : IQueryHandler<GetCommentRepliesQuery,IGenericPaginatorResult<CommentDto>>
{
    private readonly ICommentRepository _commentQueryRepository;
    private readonly IPaginator _paginator;

    public GetCommentRepliesQueryHandler(ICommentRepository commentRepository, IPaginator paginator)
    {
        _commentQueryRepository = commentRepository;
        _paginator = paginator;
    }

    public async Task<IGenericPaginatorResult<CommentDto>> Handle(GetCommentRepliesQuery request, CancellationToken cancellationToken)
    {
        ISpecification<Comment> specification = new CommentWithPublicPostSpecification(request.Id);
        // gets first comment
        Comment? comment = await _commentQueryRepository.FindBySpecificationAsync(specification);
        if (comment == null)
            throw new NotFoundException("Comment not found !");

        IGenericPaginatorResult<CommentDto> result = await _paginator.Paginate(
            _commentQueryRepository.GetQuery(new GetCommentCommentsSpecification(comment.Id)), new CommentWithUserMapper(),
            request.Page.Value);

        return result;

    }
}