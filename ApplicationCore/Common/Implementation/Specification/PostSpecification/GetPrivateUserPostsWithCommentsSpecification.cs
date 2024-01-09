using Domain.Common.Specification.Base;
using Domain.Enum;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.PostSpecification;

public class GetPrivateUserPostsWithCommentsSpecification : SpecificationBase<Post>
{
    public GetPrivateUserPostsWithCommentsSpecification(int id, int commentCount = 3)
    {
        AddIncludes(p => p.Comments.OrderBy(c => c.ReactionCount).Take(commentCount));
        AddIncludes($"{nameof(Post.Comments)}.{nameof(Comment.User)}");
        AddCriteria(p => p.User.Id == id);
        AddCriteria(p => p.Status == StatusEnum.Visible || p.Status == StatusEnum.Hidden);
        SetEntityTracking(false);
    }
        
    
}