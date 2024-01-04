using Bogus;
using Domain.Model.Generic;
using FileEntity = Domain.Model.Generic.File;

namespace Infrastructure.Dev.Seed;

public class AlbumSeeder
{
    private List<IUser> _users;

    private Random _random = new Random();

    private AlbumRatingSeeder? _albumRatingSeeder;

    private readonly Faker _faker = new Faker();

    private List<FileEntity>? _files;

    public AlbumSeeder(List<IUser> users)
    {
        _users = users;
    }

    public void AddRatingSeeder(AlbumRatingSeeder seeder)
    {
        _albumRatingSeeder = seeder;
    }

    public List<Album> CreateAlbums(int albumCount)
    {
        return Enumerable.Range(1, albumCount).Select(i =>
        {
            Album album = CreateAlbum();
            if (_albumRatingSeeder != null)
            {
                album.Rating = _albumRatingSeeder.CreateAlbumRatings(album, 20);
            }

            return album;
        }).ToList();
    }
    
    private Album CreateAlbum()
    {
        return new Album()
        {
            Title = _faker.Lorem.Text(),
            Description = _faker.Lorem.Paragraph(3),
            Files = GetRadomFilesCollection(),
            User = RandomizeUser(),
        };
    }

    public void AddFiles(List<FileEntity> files)
    {
        _files = files;
    }

    private IUser RandomizeUser()
    {
        return _users[_random.Next(_users.Count)];
    }

    private List<FileEntity> GetRadomFilesCollection()
    {
        if (_files == null)
        {
            return new List<FileEntity>();  
        }

        FileEntity[] files = _files.ToArray();
        _random.Shuffle(files);
        int randomIndex = _random.Next(_files.Count);
        int randomCount = _random.Next(_files.Count - randomIndex);
        return new List<FileEntity>(files).GetRange(randomIndex, randomCount);
    }
}
