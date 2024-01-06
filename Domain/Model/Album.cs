using Domain.Model.Join;

namespace Domain.Model;

public class Album: UserManyToOneJoinWithUidIdentity, IEntity
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<File> Files { get; set; }
    
    public ICollection<AlbumRating> Rating { get; set; }

    public Album() : base()
    {
        this.Rating = new List<AlbumRating>();
    }
}