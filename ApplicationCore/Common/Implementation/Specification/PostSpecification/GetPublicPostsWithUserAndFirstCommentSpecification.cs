using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.PostSpecification;

public class GetPublicPostsWithUserAndFirstCommentSpecification : PublicPostSpecification
{
    public GetPublicPostsWithUserAndFirstCommentSpecification()
    {
        AddIncludes(p => p.User);
        AddIncludes(nameof(Post.Comments),nameof(Comment.User));
        AddIncludes(p => p.Comments.Where(c => c.Parent == null).OrderBy(c => c.ReactionCount).Take(1));
        SetEntityTracking(false);
    }

}