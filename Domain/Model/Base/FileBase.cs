using Domain.Enum;
using Domain.Model.Interface;
using Domain.Model.Join;

namespace Domain.Model.Base;

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