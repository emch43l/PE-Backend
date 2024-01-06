using Domain.Common.Specification.Base;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.ReactionSpecification;

public class CommentReactionUserSpecification : SpecificationBase<CommentReaction>
{
    public CommentReactionUserSpecification(Comment comment, IUser user)
    {
        AddCriteria(c => c.Parent == comment);
        AddCriteria(c => c.User == user);
    }
}