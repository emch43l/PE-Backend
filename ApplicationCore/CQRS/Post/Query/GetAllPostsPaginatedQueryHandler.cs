using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Common.Implementation.Repository;
using ApplicationCore.Common.Implementation.Specification.Post;
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
    private readonly IValidator<GetAllPostsPaginatedQuery> _validator;
    private readonly IPostRepository _postRepository;

    public GetAllPostsPaginatedQueryHandler(
        IValidator<GetAllPostsPaginatedQuery> validator, 
        IPostRepository postRepository)
    {
        _validator = validator;
        _postRepository = postRepository;
    }

    public async Task<GenericPaginatorResult<PostDto>> Handle(GetAllPostsPaginatedQuery request,
        CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new PaginatorException();
        }

        IGenericPaginator<PostEntity, PostDto> paginator = new GenericPaginator<PostEntity, PostDto>();

        IQueryable<PostEntity> query = _postRepository.GetPostsWithUserAndFirstCommentQuery();
        GenericPaginatorResult<PostDto> result = 
            await paginator
                .SetPageSize(request.ItemsPerPage)
                .Paginate(query, new PostWithUserAndSingleCommentMapper(), request.PageNumber);
        return result;

    }
}