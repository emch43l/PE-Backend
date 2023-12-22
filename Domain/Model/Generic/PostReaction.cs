using Domain.Enum;
using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class PostReaction: UserManyToOneJoinWithUidIdentity, IEntity
{
    public Post Post { get; set; }
    
    public ReactionTypeEnum ReactionType { get; set; }
    
    public DateTime Date { get; set; }

    public PostReaction() : base()
    {
        
    }
}