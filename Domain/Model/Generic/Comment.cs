using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class Comment: UserManyToOneJoinWithUidIdentity, IEntity
{
    public int? ParentId { get; set; }
    
    public Comment? Parent { get; set; }
    
    public ICollection<Comment> Replies { get; set; }
    
    public int RepliesCount { get; set; }
    
    public string Content { get; set; }
    
    public DateTime DateCreated { get; set; }
    
    public Post Post { get; set; }
    
    public File? File { get; set; }

    public ICollection<CommentReaction> Reactions { get; set; }
    
    public int ReactionCount { get; set; }

    public Comment() : base()
    {
        this.Reactions = new List<CommentReaction>();
    }
}