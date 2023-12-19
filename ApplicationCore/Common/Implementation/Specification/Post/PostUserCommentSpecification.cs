using ApplicationCore.Common.Implementation.Entity;
using Domain.Common.Specification.Base;

namespace ApplicationCore.Common.Implementation.Specification.Post;

public class PostUserCommentSpecification : SpecificationBase<PostEntity>
{
    public PostUserCommentSpecification()
    {
        this.AddInclude(x => x.Comments);
        this.AddInclude(x => x.User);
    }
}