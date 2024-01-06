using Domain.Enum;
using Domain.Model.Interface;
using Domain.Model.Join;

namespace Domain.Model;

public class Post: UserManyToOneJoinWithUidIdentity, IEntity, IReactionParent<Post,PostReaction>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public StatusEnum Status { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
    
    public int CommentCount { get; set; }
    
    public ICollection<PostReaction> Reactions { get; set; }
    
    public int ReactionCount { get; set; }
    
    public ICollection<File> Files { get; set; }

    public Post() : base()
    {
        this.Files = new List<File>();
        this.Reactions = new List<PostReaction>();
        this.Comments = new List<Comment>();
    }
}