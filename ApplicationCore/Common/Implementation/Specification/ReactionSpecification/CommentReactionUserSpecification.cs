using Domain.Common.Specification.Base;
using Domain.Model.Generic;

namespace ApplicationCore.Common.Implementation.Specification.ReactionSpecification;

public class CommentReactionUserSpecification : SpecificationBase<CommentReaction>
{
    public CommentReactionUserSpecification(Comment comment, IUser user)
    {
        AddCriteria(c => c.Comment == comment);
        AddCriteria(c => c.User == user);
    }
}