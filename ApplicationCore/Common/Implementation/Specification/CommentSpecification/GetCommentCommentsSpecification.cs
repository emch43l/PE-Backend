using Domain.Common.Specification.Base;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.CommentSpecification;

public class GetCommentCommentsSpecification : SpecificationBase<Comment>
{
    public GetCommentCommentsSpecification(int id)
    {
        AddIncludes(c => c.Reactions);
        AddIncludes(c => c.User);         
        AddCriteria(c => c.Parent != null && c.Parent.Id == id);
    }
}