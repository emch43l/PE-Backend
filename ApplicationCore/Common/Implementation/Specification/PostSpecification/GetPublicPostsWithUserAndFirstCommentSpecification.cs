using Domain.Common.Specification.Base;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.PostSpecification;

public class GetPublicPostsWithUserAndFirstCommentSpecification : PublicPostSpecification
{
    public GetPublicPostsWithUserAndFirstCommentSpecification()
    {
        AddIncludes(p => p.User);
        AddIncludes(p => p.Comments.OrderBy(c => c.ReactionCount).Take(1));
        AddIncludes(p => p.Comments.Select(c => c.User));
        SetEntityTracking(false);
    }

}