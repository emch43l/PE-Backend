using Domain.Model.Join;

namespace Domain.Model;

public class AlbumRatingEntity<TKey> : UserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public AlbumEntity<TKey> Album{ get; set; }
    
    public int Raintg { get; set; }

    public AlbumRatingEntity() : base()
    {
        
    }
}