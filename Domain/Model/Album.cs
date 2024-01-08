using Domain.Model.Interface;
using Domain.Model.Join;

namespace Domain.Model;

public class Album: UserManyToOneJoinWithUidIdentity, IEntity, IRatingParent<Album,AlbumRating>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<File> Files { get; set; }
    
    public int FileCount { get; set; }
    
    public ICollection<AlbumRating> Rating { get; set; }
    
    public int NumberOfRatingVotes { get; set; }
    
    public double AverageRating { get; set; }

    public Album() : base()
    {
        this.Rating = new List<AlbumRating>();
    }
}