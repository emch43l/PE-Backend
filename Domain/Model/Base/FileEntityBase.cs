using Domain.Model.Join;

namespace Domain.Model.Base;

public class FileEntityBase<TKey>: UserManyToOneJoinWithUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public string Format { get; set; }
    
    public string Slug { get; set; }
    
    public string Name { get; set; }
    
    public long Size { get; set; }
    
    public DateTime Date { get; set; }
    
}