using Domain.Enum;

namespace Domain.Model.Interface;

public interface IRating<TParent,TRating> where TParent: IRatingParent<TParent,TRating>
{
    public TParent Parent{ get; set; }
    
    public AlbumRatingEnum Raintg { get; set; }
}