namespace Domain.Model.Interface;

public interface IRatingParent<TParent,TRating> where TParent: IRatingParent<TParent,TRating>
{
    ICollection<TRating> Rating { get; set; }
    int NumberOfRatingVotes { get; set; }
    
    double AverageRating { get; set; }
}