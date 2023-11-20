using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class GenericAlbumEntity<Key>: GenericUserManyToOneJoinWithUidIdentity<Key> where Key : IEquatable<Key>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<GenericFileEntity<Key>> Files { get; set; }
    
    public ICollection<GenericAlbumRatingEntity<Key>> Rating { get; set; }

    public GenericAlbumEntity() : base()
    {
        this.Rating = new List<GenericAlbumRatingEntity<Key>>();
    }
}