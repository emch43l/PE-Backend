using Domain.Enum;

namespace WebAPI.Requests;

public class CreatePostRequest
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public StatusEnum Status { get; set; }
}