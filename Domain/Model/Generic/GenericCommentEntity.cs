using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class GenericCommentEntity<TKey>: GenericUserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public GenericCommentEntity<TKey>? Previous { get; set; }
    
    public string Content { get; set; }
    
    public DateTime DateCreated { get; set; }
    
    public GenericPostEntity<TKey> Post { get; set; }
    
    public GenericFileEntity<TKey>? File { get; set; }

    public ICollection<GenericCommentReactionEntity<TKey>> Reactions { get; set; }
    
    public int ReactionCount { get; set; }

    public GenericCommentEntity() : base()
    {
        this.Reactions = new List<GenericCommentReactionEntity<TKey>>();
    }
}