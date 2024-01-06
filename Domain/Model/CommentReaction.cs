using Domain.Enum;
using Domain.Model.Base;
using Domain.Model.Interface;
using Domain.Model.Join;

namespace Domain.Model;

public class CommentReaction: UserManyToOneJoinWithUidIdentity, IEntity, IReaction<Comment,CommentReaction>
{
    public Comment Parent { get; set; }
    public ReactionTypeEnum ReactionType { get; set; }
    public DateTime Date { get; set; }
    
    public CommentReaction() : base()
    {
        
    }
}