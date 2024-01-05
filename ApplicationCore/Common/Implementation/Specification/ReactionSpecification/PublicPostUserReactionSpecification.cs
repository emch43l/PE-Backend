using Domain.Common.Specification.Base;
using Domain.Enum;
using Domain.Model.Generic;

namespace ApplicationCore.Common.Implementation.Specification.ReactionSpecification;

public class PublicPostUserReactionSpecification : SpecificationBase<PostReaction>
{
    public PublicPostUserReactionSpecification(Post post, IUser user)
    {
        AddCriteria(r => r.Post == post);
        AddCriteria(r => r.Post.Status == StatusEnum.Visible);
        AddCriteria(r => r.User == user);
        
    }
}