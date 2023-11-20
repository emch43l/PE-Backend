using Domain.Model.Generic;
using Domain.Model.Generic.Interface;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Entity;

public class UserEntity : IdentityUser<int>, IGenericUser<int>
{
    public Guid Guid { get; set; }
    
    public ICollection<GenericCommentEntity<int>> Comments { get; set; }
    
    public ICollection<GenericAlbumEntity<int>> Albums { get; set; }
    
    public ICollection<GenericAlbumRatingEntity<int>> AlbumRatings { get; set; }
    
    public ICollection<GenericCommentReactionEntity<int>> CommentReactions { get; set; }
    
    public ICollection<GenericFileEntity<int>> Files { get; set; }

    public ICollection<GenericPostReactionEntity<int>> PostReactions { get; set; }
    
    public ICollection<GenericPostEntity<int>> Posts { get; set; }
    
    
    public UserEntity()
    {
        Guid = Guid.NewGuid();
        Comments = new List<GenericCommentEntity<int>>();
        Albums = new List<GenericAlbumEntity<int>>();
        AlbumRatings = new List<GenericAlbumRatingEntity<int>>();
        CommentReactions = new List<GenericCommentReactionEntity<int>>();
        Files = new List<GenericFileEntity<int>>();
        PostReactions = new List<GenericPostReactionEntity<int>>();
        Posts = new List<GenericPostEntity<int>>();
    }

}