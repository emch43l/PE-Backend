using Domain.Model.Join;

namespace Domain.Model;

public class AlbumEntity<Key>: UserManyToOneJoinWithUidIdentity<Key> where Key : IEquatable<Key>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<FileEntity<Key>> Files { get; set; }
    
    public ICollection<AlbumRatingEntity<Key>> Rating { get; set; }

    public AlbumEntity() : base()
    {
        this.Rating = new List<AlbumRatingEntity<Key>>();
    }
}