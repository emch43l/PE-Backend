using Domain.Common.Specification.Base;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.CommentSpecification;

public class GetFewCommentsWithUserSpecification : GetPostCommentsSpecification
{
    public GetFewCommentsWithUserSpecification(int id, int commentCount = 5) : base(id)
    {
        SetTake(commentCount);
        AddOrderBy(c => c.ReactionCount);
        AddIncludes(c => c.User);
    }
}