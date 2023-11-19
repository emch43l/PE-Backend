using Domain.Enum;
using Domain.Model.Join;

namespace Domain.Model;

public class PostEntity<TKey>: UserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public StatusEnum Status { get; set; }
    
    public ICollection<CommentEntity<TKey>> Comments { get; set; }
    
    public ICollection<PostReactionEntity<TKey>> Reactions { get; set; }
    
    public ICollection<FileEntity<TKey>> Files { get; set; }

    public PostEntity() : base()
    {
        this.Files = new List<FileEntity<TKey>>();
        this.Reactions = new List<PostReactionEntity<TKey>>();
        this.Comments = new List<CommentEntity<TKey>>();
    }
}