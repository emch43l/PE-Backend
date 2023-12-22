using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Common.Implementation.Repository;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using Domain.Exception;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public class GetAllPostsPaginatedQueryHandler: IRequestHandler<GetAllPostsPaginatedQuery,GenericPaginatorResult<PostDto>>
{
    private readonly IGenericPaginator _paginator;
    private readonly IValidator<GetAllPostsPaginatedQuery> _validator;
    private readonly IPostRepository _postRepository;

    public GetAllPostsPaginatedQueryHandler(
        IValidator<GetAllPostsPaginatedQuery> validator, 
        IPostRepository postRepository, IGenericPaginator paginator)
    {
        _validator = validator;
        _postRepository = postRepository;
        _paginator = paginator;
    }

    public async Task<GenericPaginatorResult<PostDto>> Handle(GetAllPostsPaginatedQuery request,
        CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new PaginatorException();
        }

        IQueryable<PostEntity> query = _postRepository.GetPostsWithUserAndFirstCommentQuery();
        GenericPaginatorResult<PostDto> result = 
            await _paginator
                .SetPageSize(request.ItemsPerPage)
                .Paginate(query, new PostWithUserAndSingleCommentMapper(), request.PageNumber);
        return result;

    }
}