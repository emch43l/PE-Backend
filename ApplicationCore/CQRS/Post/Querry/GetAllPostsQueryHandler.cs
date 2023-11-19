using Domain.Common.Repository.PostRepository;
using Domain.Model;
using MediatR;

namespace ApplicationCore.CQRS.Post.Querry;

public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery<int>,List<PostEntity<int>>>
{
    private readonly IPostRepository<int> _postRepository;

    public GetAllPostsQueryHandler(IPostRepository<int> postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<List<PostEntity<int>>> Handle(GetAllPostsQuery<int> request, CancellationToken cancellationToken)
    {
        return await _postRepository.FindAllAsync();
    }
}