namespace ApplicationCore.Dto;

public class CommentDto
{
    public int ReactionCount { get; set; }
    public string Content { get; set; }
    
    public DateTime DateCreated { get; set; }
    
    public string UserName { get; set; }
}