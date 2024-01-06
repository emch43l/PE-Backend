using ApplicationCore.Common.Implementation.Specification.ReactionSpecification;
using ApplicationCore.Service;
using Domain.Common.Repository;
using Domain.Exception;
using Domain.Model;
using Domain.Model.Interface;
using FluentValidation;
using FluentValidation.Results;
using ValidationException = Domain.Exception.ValidationException;

namespace ApplicationCore.CQRS.PostOperations.Command;

public class AddReactionToPostCommandHandler : ICommandHandler<AddReactionToPostCommand>
{
    private readonly IIdentityService _identityService;

    private readonly IPostReactionRepository _postReactionRepository;

    private readonly IPostRepository _postRepository;

    private readonly IValidator<AddReactionToPostCommand> _validator;

    public AddReactionToPostCommandHandler(IIdentityService identityService, IPostReactionRepository postReactionRepository, IPostRepository postRepository, IValidator<AddReactionToPostCommand> validator)
    {
        _identityService = identityService;
        _postReactionRepository = postReactionRepository;
        _postRepository = postRepository;
        _validator = validator;
    }

    public async Task<Guid> Handle(AddReactionToPostCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(
                String.Join(',', validationResult.Errors.Select(vr => vr.ErrorMessage))
            );
        }
        
        IUser user = await _identityService.GetUserByClaimAsync(request.User);
        Post? post = await _postRepository.FindByGuidAsync(request.PostId);

        if (post == null)
            throw new PostNotFoundException();

        PostReaction? reaction =
            await _postReactionRepository.FindBySpecificationAsync(new PublicPostUserReactionSpecification(post,user));

        if (reaction == null)
        {
            reaction = new PostReaction()
            {
                Date = DateTime.Now,
                Parent = post,
                ReactionType = request.Reaction,
                UserId = user.Id
            };

            await _postReactionRepository.AddAsync(reaction, false);
        }
        else
        {
            if (reaction.ReactionType == request.Reaction)
            {
                await _postReactionRepository.Remove(reaction, false);
            }
            else
            {
                reaction.ReactionType = request.Reaction;
                await _postReactionRepository.UpdateAsync(reaction, false);
            }
        }

        await _postRepository.SaveChangesAsync(cancellationToken);

        return reaction.Guid;
    }
}