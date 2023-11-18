using Domain.Model.Join;

namespace Domain.Model;

public class CommentEntity<TKey>: UserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public CommentEntity<TKey>? Previous { get; set; }
    
    public string Content { get; set; }
    
    public PostEntity<TKey> PostEntity { get; set; }
    
    public FileEntity<TKey> FileEntity { get; set; }
    
    public ICollection<CommentReactionEntity<TKey>> Reactions { get; set; }

    public CommentEntity()
    {
        this.Reactions = new List<CommentReactionEntity<TKey>>();
    }
}