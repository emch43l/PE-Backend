using ApplicationCore.Common.Implementation.Entity;
using Domain.Common.Specification.Base;

namespace ApplicationCore.Common.Implementation.Specification.Post;

public class PostWithUserSpecification : SpecificationBase<PostEntity>
{
    public PostWithUserSpecification()
    {
        this.AddInclude(x => x.User);
    }
}