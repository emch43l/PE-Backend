namespace ApplicationCore.Dto;

public class AlbumDto
{
    public Guid Id;
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int NumberOfVotes { get; set; }
    
    public double AverageRating { get; set; }
}