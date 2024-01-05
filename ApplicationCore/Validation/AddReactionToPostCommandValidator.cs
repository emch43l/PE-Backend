using ApplicationCore.CQRS.PostOperations.Command;
using FluentValidation;

namespace ApplicationCore.Validation;

public class AddReactionToPostCommandValidator : AbstractValidator<AddReactionToPostCommand>
{
    public AddReactionToPostCommandValidator()
    {
        RuleFor(x => x.Reaction).IsInEnum().WithMessage("Wrong reaction !");
    }
}