using ApplicationCore.CQRS.Post.Query;
using FluentValidation;

namespace ApplicationCore.Validation;

public class GetAllPostsPaginatedQueryValidator : AbstractValidator<GetAllPostsPaginatedQuery>
{
    public GetAllPostsPaginatedQueryValidator()
    {
        RuleFor(x => x.PageNumber).InclusiveBetween(1, int.MaxValue);
        RuleFor(x => x.ItemsPerPage).InclusiveBetween(5, 20);
    }
}