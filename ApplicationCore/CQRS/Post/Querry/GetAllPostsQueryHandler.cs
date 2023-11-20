using ApplicationCore.Common.Implementation.EntityImplementation;
using ApplicationCore.Common.Implementation.RepositoryImplementation;
using Domain.Model.Generic;
using MediatR;

namespace ApplicationCore.CQRS.Post.Querry;

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