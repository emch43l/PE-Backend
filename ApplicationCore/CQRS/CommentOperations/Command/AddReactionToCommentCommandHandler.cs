using ApplicationCore.Common.Implementation.Specification.ReactionSpecification;
using ApplicationCore.Service;
using Domain.Common.Repository;
using Domain.Exception;
using Domain.Model;
using Domain.Model.Interface;
using FluentValidation;
using FluentValidation.Results;
using ValidationException = FluentValidation.ValidationException;

namespace ApplicationCore.CQRS.CommentOperations.Command;

public class AddReactionToCommentCommandHandler : ICommandHandler<AddReactionToCommentCommand>
{
    private readonly IIdentityService _identityService;
    private readonly ICommentRepository _commentRepository;
    private readonly IValidator<AddReactionToCommentCommand> _validator;
    private readonly ICommentReactionRepository _commentReactionRepository;

    public AddReactionToCommentCommandHandler(IIdentityService identityService, ICommentRepository commentRepository, IValidator<AddReactionToCommentCommand> validator, ICommentReactionRepository commentReactionRepository)
    {
        _identityService = identityService;
        _commentRepository = commentRepository;
        _validator = validator;
        _commentReactionRepository = commentReactionRepository;
    }

    public async Task<Guid> Handle(AddReactionToCommentCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(
                String.Join(',', validationResult.Errors.Select(vr => vr.ErrorMessage))
            );
        }
        
        IUser user = await _identityService.GetUserByClaimAsync(request.User);
        Comment? comment = await _commentRepository.FindByGuidAsync(request.CommentId);

        if (comment == null)
            throw new CommentNotFoundException();

        CommentReaction? reaction =
            await _commentReactionRepository.FindBySpecificationAsync(new CommentReactionUserSpecification(comment,user));

        if (reaction == null)
        {
            reaction = new CommentReaction()
            {
                Date = DateTime.Now,
                Parent = comment,
                ReactionType = request.Reaction,
                UserId = user.Id
            };

            await _commentReactionRepository.AddAsync(reaction, false);
        }
        else
        {
            if (reaction.ReactionType == request.Reaction)
            {
                await _commentReactionRepository.Remove(reaction, false);
            }
            else
            {
                reaction.ReactionType = request.Reaction;
                await _commentReactionRepository.UpdateAsync(reaction, false);
            }
        }

        await _commentRepository.SaveChangesAsync(cancellationToken);

        return reaction.Guid;
    }
}