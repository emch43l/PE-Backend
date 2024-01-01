using Domain.Enum;

namespace WebAPI.Requests;

public class UpdatePostRequest
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public StatusEnum Status { get; set; }
}