using Domain.Enum;

namespace ApplicationCore.Dto;

public class PostWithCommentsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public StatusEnum Status { get; set; }
    
    public IEnumerable<CommentDto> Comments { get; set; }
    
    public int CommentCount { get; set; }
    
    public int ReactionCount { get; set; }
    
    public PostWithCommentsDto()
    {
        Comments = new List<CommentDto>();
    }
}