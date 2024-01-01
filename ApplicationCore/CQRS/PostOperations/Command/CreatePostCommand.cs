using System.Security.Claims;
using Domain.Enum;

namespace ApplicationCore.CQRS.PostOperations.Command;

public class CreatePostCommand : ICommand
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public StatusEnum Status { get; set; }
    
    public ClaimsPrincipal User { get; set; }

    public CreatePostCommand(string title, string description, ClaimsPrincipal user, StatusEnum status)
    {
        Title = title;
        Description = description;
        User = user;
        Status = status;
    }
}