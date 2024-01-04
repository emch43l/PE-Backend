using Domain.Model.Generic;

namespace Infrastructure.Dev.Seed;

public class AlbumSeeder
{
    private List<IUser> _users;

    private Random _random = new Random();

    private AlbumRatingSeeder? _albumRatingSeeder;

    public AlbumSeeder(List<IUser> users)
    {
        _users = users;
    }

    public void AddRatingSeeder(AlbumRatingSeeder seeder)
    {
        _albumRatingSeeder = seeder;
    }

    /*public List<Album> CreateAlbums
    {
        return new List<Album>();
    }
    
    private Album CreateAlbum()
    {
        return new Album()
    }*/
}