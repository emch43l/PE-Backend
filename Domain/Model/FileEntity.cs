using Domain.Model.Base;
using Domain.Model.Join;

namespace Domain.Model;

public class FileEntity<TKey>: FileEntityBase<TKey> where TKey: IEquatable<TKey>
{
    public ICollection<AlbumEntity<TKey>> Albums { get; set; }
    
    public PostEntity<TKey>? Post { get; set; }
    
    public CommentEntity<TKey>? Comment { get; set; }
    
    public FileEntity() : base()
    {
        Albums = new List<AlbumEntity<TKey>>();
    }
}