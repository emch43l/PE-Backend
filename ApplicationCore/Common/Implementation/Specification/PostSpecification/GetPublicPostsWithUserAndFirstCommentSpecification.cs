using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.PostSpecification;

public class GetPublicPostsWithUserAndFirstCommentSpecification : PublicPostSpecification
{
    public GetPublicPostsWithUserAndFirstCommentSpecification()
    {
        AddIncludes(p => p.User);
        AddIncludes(p => p.Comments.OrderBy(c => c.ReactionCount).Take(1));
        AddIncludes(nameof(Post.Comments),nameof(Comment.User));
        SetEntityTracking(false);
    }

}