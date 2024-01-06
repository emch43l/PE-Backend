using Domain.Enum;
using Domain.Model.Interface;
using Domain.Model.Join;

namespace Domain.Model;

public class PostReaction: UserManyToOneJoinWithUidIdentity, IEntity, IReaction<Post,PostReaction>
{
    public Post Parent { get; set; }
    public ReactionTypeEnum ReactionType { get; set; }
    
    public DateTime Date { get; set; }

    public PostReaction() : base()
    {
        
    }
}