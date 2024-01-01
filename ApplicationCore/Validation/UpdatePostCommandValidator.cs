using ApplicationCore.CQRS.PostOperations.Command;
using FluentValidation;

namespace ApplicationCore.Validation;

public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status !");
        RuleFor(x => x.PostId)
            .NotEmpty().WithMessage("PostId cannot be empty !");
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