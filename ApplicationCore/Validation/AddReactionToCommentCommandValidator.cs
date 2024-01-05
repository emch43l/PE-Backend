using ApplicationCore.CQRS.CommentOperations.Command;
using FluentValidation;

namespace ApplicationCore.Validation;

public class AddReactionToCommentCommandValidator : AbstractValidator<AddReactionToCommentCommand>
{
    public AddReactionToCommentCommandValidator()
    {
        RuleFor(c => c.Reaction).IsInEnum().WithMessage("Wrong reaction !");
    }
}