using ApplicationCore.Common.Implementation.Specification.PostSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using Domain.Common.Repository;
using Domain.Common.Repository.QueryRepository;
using Domain.Exception;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetAllPostsPaginatedQueryHandler: IQueryHandler<GetAllPostsPaginatedQuery,GenericPaginatorResult<PostDto>>
{
    private readonly IGenericPaginator _paginator;
    private readonly IValidator<GetAllPostsPaginatedQuery> _validator;
    private readonly IPostQueryRepository _postRepository;

    public GetAllPostsPaginatedQueryHandler(
        IValidator<GetAllPostsPaginatedQuery> validator, 
        IPostQueryRepository postRepository, IGenericPaginator paginator)
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
        
        GenericPaginatorResult<PostDto> result = 
            await _paginator
                .SetPageSize(request.ItemsPerPage)
                .Paginate(
                    _postRepository.GetPublicPostsWithUserAndFirstCommentQuery().ApplySpecification(new PublicPostSpecification()).GetQuery(), 
                    new PostWithUserAndSingleCommentMapper(), 
                    request.PageNumber
                    );
        
        return result;

    }
}