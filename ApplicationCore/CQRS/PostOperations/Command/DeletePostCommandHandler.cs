using ApplicationCore.Service;
using Domain.Common.Repository;
using Domain.Enum;
using Domain.Exception;
using Domain.Model;

namespace ApplicationCore.CQRS.PostOperations.Command;

public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
{
    private readonly IPostRepository _postRepository;
    private readonly IIdentityService _identityService;

    public DeletePostCommandHandler(IPostRepository postRepository, IIdentityService identityService)
    {
        _postRepository = postRepository;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        Post? post = await _postRepository.FindByGuidAsync(request.Id);
        if (post == null)
            throw new PostNotFoundException();

        IUser user = await _identityService.GetUserByClaimAsync(request.User);

        if (post.UserId != user.Id)
            throw new PostNotFoundException();

        post.Status = StatusEnum.Deleted;
        await _postRepository.SaveChangesAsync(cancellationToken);
        
        return post.Guid;
    }
}