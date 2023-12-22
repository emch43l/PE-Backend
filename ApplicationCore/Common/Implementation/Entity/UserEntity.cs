using Domain.Model;
using Domain.Model.Generic;
using Domain.Model.Generic.Interface;

namespace ApplicationCore.Common.Implementation.Entity;

public class UserEntity : IGenericUser<int>, IEntity
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public ICollection<GenericCommentEntity<int>> Comments { get; set; }
    public ICollection<GenericAlbumEntity<int>> Albums { get; set; }
    public ICollection<GenericAlbumRatingEntity<int>> AlbumRatings { get; set; }
    public ICollection<GenericCommentReactionEntity<int>> CommentReactions { get; set; }
    public ICollection<GenericFileEntity<int>> Files { get; set; }
    public ICollection<GenericPostReactionEntity<int>> PostReactions { get; set; }
    public ICollection<GenericPostEntity<int>> Posts { get; set; }
    public Guid Guid { get; set; }
}