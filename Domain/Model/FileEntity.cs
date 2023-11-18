using Domain.Model.Join;

namespace Domain.Model;

public class FileEntity<TKey>: UserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public string Format { get; set; }
    
    public string Slug { get; set; }
    
    public string Name { get; set; }
    
    public long Size { get; set; }
    
    public DateTime Date { get; set; }
    
    public PostEntity<TKey>? Post { get; set; }
    
    public CommentEntity<TKey>? Comment { get; set; }
    
    public ICollection<AlbumEntity<TKey>> Albums { get; set; }

    public FileEntity()
    {
        this.Albums = new List<AlbumEntity<TKey>>();
    }
}