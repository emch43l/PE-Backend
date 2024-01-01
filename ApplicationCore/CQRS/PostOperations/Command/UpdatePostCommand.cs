using System.Security.Claims;
using Domain.Enum;

namespace ApplicationCore.CQRS.PostOperations.Command;

public class UpdatePostCommand : ICommand
{
    public Guid PostId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public StatusEnum Status { get; set; }
    
    public ClaimsPrincipal User { get; set; }
    
    public bool IgnoreResourceOwner { get; set; }

    public UpdatePostCommand(Guid id, string title, string description, StatusEnum status, ClaimsPrincipal user, bool ignoreResourceOwner = false)
    {
        PostId = id;
        Title = title;
        Description = description;
        Status = status;
        User = user;
        IgnoreResourceOwner = ignoreResourceOwner;
    }
}