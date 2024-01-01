using ApplicationCore.CQRS.PostOperations.Command;
using FluentValidation;

namespace ApplicationCore.Validation;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Wrong status !");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description field cant be empty !")
            .Length(1,500).WithMessage("Description should be between 1 and 500 characters length !");
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title field cant be empty !")
            .Length(1, 100)
            .WithMessage("Title should be between 1 and 100 characters length !");
    }
}