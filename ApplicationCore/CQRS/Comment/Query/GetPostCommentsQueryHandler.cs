using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using Domain.Common.Repository;
using Domain.Common.Repository.QueryRepository;
using Domain.Exception;
using Domain.Model.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace ApplicationCore.CQRS.Comment.Query;

public class GetPostCommentsQueryHandler : IQueryHandler<GetPostCommentsQuery,IGenericPaginatorResult<CommentDto>>
{
    private const int CommentNumberPerPage = 5;
    
    private readonly ICommentQueryRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    private readonly IGenericPaginator _genericPaginator;
    private readonly IValidator<GetPostCommentsQuery> _validator;
    public GetPostCommentsQueryHandler(ICommentQueryRepository repository,
        IPostRepository postRepository,
        IGenericPaginator genericPaginator,
        IValidator<GetPostCommentsQuery> validator)
    {
        _postRepository = postRepository;
        _genericPaginator = genericPaginator;
        _validator = validator;
        _commentRepository = repository;
    }

    public async Task<IGenericPaginatorResult<CommentDto>> Handle(GetPostCommentsQuery query, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(query,cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new PaginatorException();
        }
        
        Post? post = await _postRepository.FindByGuidAsync(query.PostId);
        if (post == null)
        {
            throw new PostNotFoundException();
        }

        IGenericPaginatorResult<CommentDto> result = await _genericPaginator.SetPageSize(CommentNumberPerPage).Paginate(
            _commentRepository.GetPostCommentsQuery(post).GetQuery(),
            new CommentWithUserMapper(), 
            query.Page
            );

        return result;
    }
}