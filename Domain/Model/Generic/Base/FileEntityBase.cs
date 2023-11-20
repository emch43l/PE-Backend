using Domain.Model.Generic.Join;

namespace Domain.Model.Generic.Base;

public class FileEntityBase<TKey>: GenericUserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public string Format { get; set; }
    
    public string Slug { get; set; }
    
    public string Name { get; set; }
    
    public long Size { get; set; }
    
    public DateTime Date { get; set; }
    
}