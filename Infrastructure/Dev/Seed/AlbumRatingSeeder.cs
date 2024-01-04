using Domain.Enum;
using Domain.Model.Generic;

namespace Infrastructure.Dev.Seed;

public class AlbumRatingSeeder
{
    private List<IUser> _users;

    private Random _random = new Random();

    private bool _randomizeRatingNumber = false;
    
    public AlbumRatingSeeder(List<IUser> users)
    {
        _users = users;
    }

    public void RandomizeRatingNumber(bool randomize = true)
    {
        _randomizeRatingNumber = randomize;
    }

    public List<AlbumRating> CreateAlbumRatings(Album album, int albumRatingCount)
    {
        return Enumerable
            .Range(1, _randomizeRatingNumber ? _random.Next(albumRatingCount+1) : albumRatingCount)
            .Select(i => CreateAlbumRating(album)).ToList();
    }

    private AlbumRating CreateAlbumRating(Album album)
    {
        AlbumRating rating = new AlbumRating()
        {
            Album = album,
            Raintg = (AlbumRatingEnum)_random.Next(5),
            User = RandomizeUser()
        };

        return rating;
    }

    private IUser RandomizeUser()
    {
        return _users[_random.Next(_users.Count)];
    }
}