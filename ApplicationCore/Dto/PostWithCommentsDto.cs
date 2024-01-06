using Domain.Enum;
using Domain.Model;

namespace ApplicationCore.Dto;

public class PostWithCommentsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public StatusField Status { get; set; }
    
    public IEnumerable<CommentDto> Comments { get; set; }
    
    public int CommentCount { get; set; }
    
    public int ReactionCount { get; set; }
    
    public PostWithCommentsDto()
    {
        Comments = new List<CommentDto>();
    }
}