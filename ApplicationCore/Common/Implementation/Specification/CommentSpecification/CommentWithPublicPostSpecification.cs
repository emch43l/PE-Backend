using Domain.Common.Specification.Base;
using Domain.Enum;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.CommentSpecification;

public class CommentWithPublicPostSpecification : SpecificationBase<Comment>
{
    public CommentWithPublicPostSpecification(Guid id)
    {
        AddCriteria(c => c.Guid == id);
        AddCriteria(c => c.Post.Status == StatusEnum.Visible);
    }
}