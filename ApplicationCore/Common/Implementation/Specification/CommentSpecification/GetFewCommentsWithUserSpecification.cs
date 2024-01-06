using Domain.Common.Specification.Base;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.CommentSpecification;

public class GetFewCommentsWithUserSpecification : SpecificationBase<Comment>
{
    public GetFewCommentsWithUserSpecification(int commentCount = 5)
    {
        SetTake(commentCount);
        AddOrderBy(c => c.ReactionCount);
        AddIncludes($"User");
    }
}