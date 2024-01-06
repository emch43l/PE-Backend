using Domain.Enum;
using Domain.Model.Interface;
using Domain.Model.Join;

namespace Domain.Model;

public class AlbumRating : UserManyToOneJoinWithUidIdentity, IEntity, IRating<Album,AlbumRating>
{
    public Album Parent { get; set; }
    
    public AlbumRatingEnum Raintg { get; set; }

    public AlbumRating() : base()
    {
        
    }
}