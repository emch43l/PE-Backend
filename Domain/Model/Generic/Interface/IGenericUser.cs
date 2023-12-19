using Domain.Common.Identity;

namespace Domain.Model.Generic.Interface;

public interface IGenericUser<TKey> : IUidIdentity<TKey> where TKey: IEquatable<TKey>
{
    TKey Id { get; set; }
    
    string UserName { get; set; }
    
    string Email { get; set; }
    
    ICollection<GenericCommentEntity<TKey>> Comments { get; set; }
    
    ICollection<GenericAlbumEntity<TKey>> Albums { get; set; }
    
    ICollection<GenericAlbumRatingEntity<TKey>> AlbumRatings { get; set; }
    
    ICollection<GenericCommentReactionEntity<TKey>> CommentReactions { get; set; }
    
    ICollection<GenericFileEntity<TKey>> Files { get; set; }
    
    ICollection<GenericPostReactionEntity<TKey>> PostReactions { get; set; }
    
    ICollection<GenericPostEntity<TKey>> Posts { get; set; }
    

}