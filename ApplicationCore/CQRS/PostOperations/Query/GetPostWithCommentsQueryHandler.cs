using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using Domain.Common.Repository;
using Domain.Exception;
using Domain.Model.Generic;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetPostWithCommentsQueryHandler : IQueryHandler<GetPostWithCommentsQuery,PostWithCommentsDto>
{
    private readonly IPostRepository _postRepository;

    public GetPostWithCommentsQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostWithCommentsDto> Handle(GetPostWithCommentsQuery request, CancellationToken cancellationToken)
    {
        IMapper<Post, PostWithCommentsDto> mapper = new PostWithCommentsMapper();
        PostWithCommentsDto? result = await mapper.MapSingle(_postRepository.GetPostWithCommentsQuery(request.PostId,request.CommentCount));
        
        if (result == null)
            throw new PostNotFoundException();
        
        return result;
    }
}