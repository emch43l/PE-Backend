using Domain.Common.Repository;
using Domain.Exception;
using Domain.Model.Generic;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetPostByGuidQueryHanlder : IRequestHandler<GetPostByGuidQuery,Post>
{
    private readonly IPostRepository _postRepository;

    public GetPostByGuidQueryHanlder(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> Handle(GetPostByGuidQuery request, CancellationToken cancellationToken)
    {
        Post? postEntity = await _postRepository.FindByGuidAsync(request.Guid);

        if (postEntity is null)
            throw new PostNotFoundException();

        return postEntity;
    }
}