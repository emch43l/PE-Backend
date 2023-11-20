using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class GenericAlbumRatingEntity<TKey> : GenericUserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public GenericAlbumEntity<TKey> GenericAlbum{ get; set; }
    
    public int Raintg { get; set; }

    public GenericAlbumRatingEntity() : base()
    {
        
    }
}