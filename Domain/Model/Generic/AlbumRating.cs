using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class AlbumRating : UserManyToOneJoinWithUidIdentity, IEntity
{
    public Album Album{ get; set; }
    
    public int Raintg { get; set; }

    public AlbumRating() : base()
    {
        
    }
}