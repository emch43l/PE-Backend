namespace ApplicationCore.Dto;

public class CommentDto
{
    public Guid Id { get; set; }
    public int ReactionCount { get; set; }
    public string Content { get; set; }
    
    public int RepliesCount { get; set; }
    
    public DateTime DateCreated { get; set; }
    
    public string UserName { get; set; }
}