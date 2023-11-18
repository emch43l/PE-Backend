using Domain.Common.Identity;

namespace Domain.Model.Interface;

public interface IUser<TKey> : IUidIdentity<TKey> where TKey: IEquatable<TKey>
{
    TKey Id { get; set; }
    
    ICollection<CommentEntity<TKey>> Comments { get; set; }
    
    ICollection<AlbumEntity<TKey>> Albums { get; set; }
    
    ICollection<AlbumRatingEntity<TKey>> AlbumRatings { get; set; }
    
    ICollection<CommentReactionEntity<TKey>> CommentReactions { get; set; }
    
    ICollection<FileEntity<TKey>> Files { get; set; }
    
    ICollection<PostReactionEntity<TKey>> PostReactions { get; set; }
    
    ICollection<PostEntity<TKey>> Posts { get; set; }
    

}