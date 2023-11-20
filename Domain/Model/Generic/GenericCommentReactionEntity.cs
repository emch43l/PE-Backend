using Domain.Enum;
using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class GenericCommentReactionEntity<TKey>: GenericUserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public GenericCommentEntity<TKey> GenericComment { get; set; }
    
    public ReactionTypeEnum ReactionType { get; set; }
    
    public DateTime Date { get; set; }

    public GenericCommentReactionEntity() : base()
    {
        
    }
}