using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Common.Implementation.Repository;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public class GetPostWithCommentsQueryHandler : IRequestHandler<GetPostWithCommentsQuery,PostWithCommentsDto>
{
    public readonly IPostRepository _postRepository;

    public GetPostWithCommentsQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostWithCommentsDto> Handle(GetPostWithCommentsQuery request, CancellationToken cancellationToken)
    {
        IMapper<PostEntity, PostWithCommentsDto> mapper = new PostWithCommentsMapper();
    }
}