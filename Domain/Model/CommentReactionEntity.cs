using Domain.Enum;
using Domain.Model.Join;

namespace Domain.Model;

public class CommentReactionEntity<TKey>: UserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public CommentEntity<TKey> CommentEntity { get; set; }
    
    public ReactionTypeEnum ReactionTypeType { get; set; }
    
    public DateTime Date { get; set; }
}