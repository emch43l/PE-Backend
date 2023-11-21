using ApplicationCore.Common.Implementation.EntityImplementation;
using ApplicationCore.Common.Implementation.RepositoryImplementation;
using ApplicationCore.Pagination;
using Domain.Exception;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public class GetAllPostsPaginatedQueryHandler: IRequestHandler<GetAllPostsPaginatedQuery,GenericPaginatorResult<PostEntity>>
{
    private readonly IGenericPaginator<PostEntity> _paginator;
    private readonly IValidator<GetAllPostsPaginatedQuery> _validator;
    private readonly IPostRepository _postRepository;

    public GetAllPostsPaginatedQueryHandler(
        IGenericPaginator<PostEntity> paginator, 
        IValidator<GetAllPostsPaginatedQuery> validator, 
        IPostRepository postRepository)
    {
        _paginator = paginator;
        _validator = validator;
        _postRepository = postRepository;
    }

    public async Task<GenericPaginatorResult<PostEntity>> Handle(GetAllPostsPaginatedQuery request,
        CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new PaginatorException();
        }

        IQueryable<PostEntity> query = _postRepository.GetQuery();
        GenericPaginatorResult<PostEntity> result = await _paginator.SetPageSize(request.ItemsPerPage).Paginate(query,request.PageNumber);
        return result;

    }
}