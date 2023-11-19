using Domain.Enum;
using Domain.Model.Join;

namespace Domain.Model;

public class PostReactionEntity<TKey>: UserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public PostEntity<TKey> Post { get; set; }
    
    public ReactionTypeEnum ReactionType { get; set; }
    
    public DateTime Date { get; set; }

    public PostReactionEntity() : base()
    {
        
    }
}