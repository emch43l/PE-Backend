using Domain.Common.Specification.Base;
using Domain.Model.Generic;

namespace ApplicationCore.Common.Implementation.Specification.PostSpecification;

public class PostUserCommentSpecification : SpecificationBase<Post>
{
    public PostUserCommentSpecification()
    {
        this.AddInclude(x => x.Comments);
        this.AddInclude(x => x.User);
    }
}