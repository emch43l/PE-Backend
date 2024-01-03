using Domain.Common.Specification.Base;
using Domain.Enum;
using Domain.Model.Generic;

namespace ApplicationCore.Specification;

public class CommentWithPublicPostSpecification : SpecificationBase<Comment>
{
    public CommentWithPublicPostSpecification(Guid id)
    {
        AddCriteria(c => c.Guid == id);
        AddCriteria(c => c.Post.Status == StatusEnum.Visible);
    }
}