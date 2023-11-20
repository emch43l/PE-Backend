using Domain.Model.Generic.Base;

namespace Domain.Model.Generic;

public class GenericFileEntity<TKey>: FileEntityBase<TKey> where TKey: IEquatable<TKey>
{
    public ICollection<GenericAlbumEntity<TKey>> Albums { get; set; }
    
    public GenericPostEntity<TKey>? Post { get; set; }
    
    public GenericCommentEntity<TKey>? Comment { get; set; }
    
    public GenericFileEntity() : base()
    {
        Albums = new List<GenericAlbumEntity<TKey>>();
    }
}