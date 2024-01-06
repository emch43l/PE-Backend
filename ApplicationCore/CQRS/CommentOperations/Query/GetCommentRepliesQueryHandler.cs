using ApplicationCore.Common.Implementation.Specification.CommentSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using Domain.Common.Repository;
using Domain.Common.Repository.QueryRepository;
using Domain.Common.Specification;
using Domain.Exception.Base;
using Domain.Model;

namespace ApplicationCore.CQRS.CommentOperations.Query;

public class GetCommentRepliesQueryHandler : IQueryHandler<GetCommentRepliesQuery,IGenericPaginatorResult<CommentDto>>
{
    private readonly ICommentQueryRepository _commentQueryRepository;
    private readonly IGenericPaginator _genericPaginator;

    public GetCommentRepliesQueryHandler(ICommentQueryRepository commentRepository, IGenericPaginator genericPaginator)
    {
        _commentQueryRepository = commentRepository;
        _genericPaginator = genericPaginator;
    }

    public async Task<IGenericPaginatorResult<CommentDto>> Handle(GetCommentRepliesQuery request, CancellationToken cancellationToken)
    {
        ISpecification<Comment> specification = new CommentWithPublicPostSpecification(request.Id);
        // gets first comment
        Comment? comment = await _commentQueryRepository.FindBySpecificationAsync(specification);
        if (comment == null)
            throw new NotFoundException("Comment not found !");

        IGenericPaginatorResult<CommentDto> result = await _genericPaginator.Paginate(
            _commentQueryRepository.GetCommentCommentsQuery(comment).GetQuery(), new CommentWithUserMapper(),
            request.Page.Value);

        return result;

    }
}