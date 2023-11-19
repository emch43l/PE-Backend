using Domain.Enum;
using Domain.Model.Join;

namespace Domain.Model;

public class CommentReactionEntity<TKey>: UserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public CommentEntity<TKey> Comment { get; set; }
    
    public ReactionTypeEnum ReactionType { get; set; }
    
    public DateTime Date { get; set; }

    public CommentReactionEntity() : base()
    {
        
    }
}