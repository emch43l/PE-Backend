using Domain.Model.Generic;
using Domain.Model.Generic.Interface;

namespace ApplicationCore.Common.Implementation.EntityImplementation;

public class UserEntity : IGenericUser<int>
{
    public int Id { get; set; }
    public ICollection<GenericCommentEntity<int>> Comments { get; set; }
    public ICollection<GenericAlbumEntity<int>> Albums { get; set; }
    public ICollection<GenericAlbumRatingEntity<int>> AlbumRatings { get; set; }
    public ICollection<GenericCommentReactionEntity<int>> CommentReactions { get; set; }
    public ICollection<GenericFileEntity<int>> Files { get; set; }
    public ICollection<GenericPostReactionEntity<int>> PostReactions { get; set; }
    public ICollection<GenericPostEntity<int>> Posts { get; set; }
    public Guid Guid { get; set; }
}