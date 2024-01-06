using Domain.Common.Specification.Base;
using Domain.Enum;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.ReactionSpecification;

public class PublicPostUserReactionSpecification : SpecificationBase<PostReaction>
{
    public PublicPostUserReactionSpecification(Post post, IUser user)
    {
        AddCriteria(r => r.Parent == post);
        AddCriteria(r => r.Parent.Status == StatusEnum.Visible);
        AddCriteria(r => r.User == user);
        
    }
}