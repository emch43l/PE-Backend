using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Common.Implementation.Repository;
using ApplicationCore.Common.Implementation.Specification.Post;
using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using Domain.Exception;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public class GetAllPostsPaginatedQueryHandler: IRequestHandler<GetAllPostsPaginatedQuery,GenericPaginatorResult<PostDto>>
{
    private readonly IGenericPaginator<PostEntity,PostDto> _paginator;
    private readonly IValidator<GetAllPostsPaginatedQuery> _validator;
    private readonly IPostRepository _postRepository;

    public GetAllPostsPaginatedQueryHandler(
        IGenericPaginator<PostEntity,PostDto> paginator, 
        IValidator<GetAllPostsPaginatedQuery> validator, 
        IPostRepository postRepository)
    {
        _paginator = paginator;
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

        IQueryable<PostEntity> query = _postRepository.GetQueryBySpecification(new PostWithUserSpecification());
        GenericPaginatorResult<PostDto> result = 
            await _paginator
                .SetPageSize(request.ItemsPerPage)
                .Paginate(query, p => new PostDto
                {
                    User = new UserDto()
                    {
                        Id = p.User.Guid,
                    },
                    ReactionCount = p.ReactionCount,
                    CommentCount = p.CommentCount,
                    Title = p.Title
                }, request.PageNumber);
        return result;

    }
}