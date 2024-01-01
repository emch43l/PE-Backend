using Domain.Common.Repository;
using Domain.Model.Generic;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery,List<Post>>
{
    private readonly IPostRepository _postRepository;

    public GetAllPostsQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<List<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        return await _postRepository.FindAllAsync();
    }
}