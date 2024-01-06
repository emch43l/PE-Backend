using Domain.Enum;
using Domain.Model.Join;

namespace Domain.Model;

public class AlbumRating : UserManyToOneJoinWithUidIdentity, IEntity
{
    public Album Album{ get; set; }
    
    public AlbumRatingEnum Raintg { get; set; }

    public AlbumRating() : base()
    {
        
    }
}