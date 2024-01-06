using Domain.Common.Identity;

namespace Domain.Model.Interface;

public interface IUser : IUidIdentity<int>, IEntity
{
    public int Id { get; set; }
    
    public Guid Guid { get; set; }
    
    public string? UserName { get; set; }
    
    public string? Email { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
    
    public ICollection<Album> Albums { get; set; }
    
    public ICollection<AlbumRating> AlbumRatings { get; set; }
    
    public ICollection<CommentReaction> CommentReactions { get; set; }
    
    public ICollection<File> Files { get; set; }
    
    public ICollection<PostReaction> PostReactions { get; set; }
    
    public ICollection<Post> Posts { get; set; }
    
}