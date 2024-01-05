using ApplicationCore.Service;
using Domain.Common.Repository;
using Domain.Exception;
using Domain.Model.Generic;
using FluentValidation;
using FluentValidation.Results;
using ValidationException = Domain.Exception.ValidationException;

namespace ApplicationCore.CQRS.PostOperations.Command;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand>
{
    private readonly IPostRepository _postRepository;
    private readonly IIdentityService _identityService;
    private readonly IValidator<UpdatePostCommand> _validator;

    public UpdatePostCommandHandler(IPostRepository postRepository, IIdentityService identityService, IValidator<UpdatePostCommand> validator)
    {
        _postRepository = postRepository;
        _identityService = identityService;
        _validator = validator;
    }

    public async Task<Guid> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        ValidationResult result = await _validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidationException(
                String.Join(',', result.Errors.Select(vr => vr.ErrorMessage))
            );
        }
        
        Post? post = await _postRepository.FindByGuidAsync(request.PostId);
        if (post == null)
            throw new PostNotFoundException();

        if (!request.IgnoreResourceOwner)
        {
            IUser user = await _identityService.GetUserByClaimAsync(request.User);
            if (post.UserId != user.Id)
                throw new PostNotFoundException();
        }

        post.Title = request.Title;
        post.Description = request.Description;
        post.Status = request.Status;

        await _postRepository.SaveChangesAsync(cancellationToken);
        return post.Guid;

    }
}