using ApplicationCore.Common.Implementation.EntityImplementation;
using ApplicationCore.Common.Implementation.RepositoryImplementation;
using Domain.Exception;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public class GetPostByGuidQueryHanlder : IRequestHandler<GetPostByGuidQuery,PostEntity>
{
    private readonly IPostRepository _postRepository;

    public GetPostByGuidQueryHanlder(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostEntity> Handle(GetPostByGuidQuery request, CancellationToken cancellationToken)
    {
        PostEntity? postEntity = await _postRepository.FindByGuidAsync(request.Guid);

        if (postEntity is null)
            throw new PostNotFoundException();

        return postEntity;
    }
}