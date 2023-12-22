using Domain.Model.Generic.Base;

namespace Domain.Model.Generic;

public class File: FileBase
{
    public ICollection<Album> Albums { get; set; }
    
    public Post? Post { get; set; }
    
    public Comment? Comment { get; set; }
    
    public File() : base()
    {
        Albums = new List<Album>();
    }
}