using Domain.Common.Specification.Base;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.CommentSpecification;

public class GetPostCommentsSpecification : SpecificationBase<Comment>
{
    public GetPostCommentsSpecification(int id)
    {
        AddCriteria(c => c.Post.Id == id);
        AddCriteria(c => c.Parent == null);
        AddIncludes(c => c.User);
        SetEntityTracking(false);
    }
}