using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Common.Implementation.Repository;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery,List<PostEntity>>
{
    private readonly IPostRepository _postRepository;

    public GetAllPostsQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<List<PostEntity>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        return await _postRepository.FindAllAsync();
    }
}