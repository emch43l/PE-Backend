using ApplicationCore.Common.Implementation.Specification.PostSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using Domain.Common.Repository.QueryRepository;
using Domain.Exception;
using Domain.Model.Generic;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetPostWithCommentsQueryHandler : IQueryHandler<GetPostWithCommentsQuery,PostWithCommentsDto>
{
    private readonly IPostQueryRepository _postRepository;

    public GetPostWithCommentsQueryHandler(IPostQueryRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostWithCommentsDto> Handle(GetPostWithCommentsQuery request, CancellationToken cancellationToken)
    {
        IMapper<Post, PostWithCommentsDto> mapper = new PostWithCommentsMapper();
        PostWithCommentsDto? result = await mapper.MapSingle(_postRepository
            .GetPostWithCommentsQuery(request.PostId, request.CommentCount)
            .ApplySpecification(new PublicPostSpecification()));
        
        if (result == null)
            throw new PostNotFoundException();
        
        return result;
    }
}