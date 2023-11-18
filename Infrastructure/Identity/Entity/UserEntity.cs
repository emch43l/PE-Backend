using Domain.Model;
using Domain.Model.Interface;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Entity;

public class UserEntity : IdentityUser<int>, IUser<int>
{
    public Guid Guid { get; set; }
    
    public ICollection<CommentEntity<int>> Comments { get; set; }
    
    public ICollection<AlbumEntity<int>> Albums { get; set; }
    
    public ICollection<AlbumRatingEntity<int>> AlbumRatings { get; set; }
    
    public ICollection<CommentReactionEntity<int>> CommentReactions { get; set; }
    
    public ICollection<FileEntity<int>> Files { get; set; }
    
    public ICollection<PostReactionEntity<int>> PostReactions { get; set; }
    
    public ICollection<PostEntity<int>> Posts { get; set; }
    
    
    public UserEntity()
    {
        Guid = new Guid();
        Comments = new List<CommentEntity<int>>();
        Albums = new List<AlbumEntity<int>>();
        AlbumRatings = new List<AlbumRatingEntity<int>>();
        CommentReactions = new List<CommentReactionEntity<int>>();
        Files = new List<FileEntity<int>>();
        PostReactions = new List<PostReactionEntity<int>>();
        Posts = new List<PostEntity<int>>();
    }
}