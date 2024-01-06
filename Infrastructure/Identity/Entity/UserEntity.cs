using Domain.Model;
using Domain.Model.Interface;
using Microsoft.AspNetCore.Identity;
using File = Domain.Model.File;

namespace Infrastructure.Identity.Entity;

public class UserEntity : IdentityUser<int>, IUser
{
    public Guid Guid { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
    
    public ICollection<Album> Albums { get; set; }
    
    public ICollection<AlbumRating> AlbumRatings { get; set; }
    
    public ICollection<CommentReaction> CommentReactions { get; set; }
    
    public ICollection<File> Files { get; set; }

    public ICollection<PostReaction> PostReactions { get; set; }
    
    public ICollection<Post> Posts { get; set; }
    
    
    public UserEntity()
    {
        Guid = Guid.NewGuid();
        Comments = new List<Comment>();
        Albums = new List<Album>();
        AlbumRatings = new List<AlbumRating>();
        CommentReactions = new List<CommentReaction>();
        Files = new List<File>();
        PostReactions = new List<PostReaction>();
        Posts = new List<Post>();
    }

}