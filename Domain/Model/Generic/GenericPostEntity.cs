using Domain.Enum;
using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class GenericPostEntity<TKey>: GenericUserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public StatusEnum Status { get; set; }
    
    public ICollection<GenericCommentEntity<TKey>> Comments { get; set; }
    
    public int CommentCount { get; set; }
    
    public ICollection<GenericPostReactionEntity<TKey>> Reactions { get; set; }
    
    public int ReactionCount { get; set; }
    
    public ICollection<GenericFileEntity<TKey>> Files { get; set; }

    public GenericPostEntity() : base()
    {
        this.Files = new List<GenericFileEntity<TKey>>();
        this.Reactions = new List<GenericPostReactionEntity<TKey>>();
        this.Comments = new List<GenericCommentEntity<TKey>>();
    }
}