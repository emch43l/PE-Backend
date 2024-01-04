using Domain.Enum;
using Domain.Model.Generic.Join;

namespace Domain.Model.Generic.Base;

public class FileBase: UserManyToOneJoinWithUidIdentity, IEntity
{
    public const char SlugSeparator = '-'; 
    
    public FileFormatEnum Format { get; set; }
    
    public string Slug
    {
        get => $"{Name}{SlugSeparator}{Guid}";
        private set => Slug = value;
    }

    public string Name { get; set; }
    
    public long Size { get; set; }
    
    public DateTime Date { get; set; }
    
}