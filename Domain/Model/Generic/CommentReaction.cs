using Domain.Enum;
using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class CommentReaction: UserManyToOneJoinWithUidIdentity, IEntity
{
    public Comment Comment { get; set; }
    
    public ReactionTypeEnum ReactionType { get; set; }
    
    public DateTime Date { get; set; }

    public CommentReaction() : base()
    {
        
    }
}