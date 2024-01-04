using Domain.Enum;
using Domain.Model.Generic.Join;

namespace Domain.Model.Generic;

public class AlbumRating : UserManyToOneJoinWithUidIdentity, IEntity
{
    public Album Album{ get; set; }
    
    public AlbumRatingEnum Raintg { get; set; }

    public AlbumRating() : base()
    {
        
    }
}