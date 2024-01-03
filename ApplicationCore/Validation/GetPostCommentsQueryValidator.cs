using ApplicationCore.CQRS.CommentOperations.Query;
using FluentValidation;

namespace ApplicationCore.Validation;

public class GetPostCommentsQueryValidator : AbstractValidator<GetPostCommentsQuery>
{
    public GetPostCommentsQueryValidator()
    {
        RuleFor(e => e.Page).InclusiveBetween(1, Int32.MaxValue);
    }
}