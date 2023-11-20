using Domain.Enum;
using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class GenericPostReactionEntity<TKey>: GenericUserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public GenericPostEntity<TKey> GenericPost { get; set; }
    
    public ReactionTypeEnum ReactionType { get; set; }
    
    public DateTime Date { get; set; }

    public GenericPostReactionEntity() : base()
    {
        
    }
}