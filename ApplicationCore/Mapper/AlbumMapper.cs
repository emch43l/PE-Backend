using System.Linq.Expressions;
using ApplicationCore.Dto;
using Domain.Model;

namespace ApplicationCore.Mapper;

public class AlbumMapper : AbstractMapper<Album,AlbumDto>
{
    public override Expression<Func<Album, AlbumDto>> GetMapperExpression()
    {
        return (Album album) => new AlbumDto()
        {
            Title = album.Title,
            Description = album.Description,
            AverageRating = album.AverageRating,
            NumberOfVotes = album.NumberOfRatingVotes
        };
    }
}