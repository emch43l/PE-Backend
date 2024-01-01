using System.Security.Claims;

namespace ApplicationCore.CQRS.PostOperations.Command;

public class DeletePostCommand : ICommand
{
    public Guid Id { get; set; }
    
    public ClaimsPrincipal User { get; set; }

    public DeletePostCommand(Guid id, ClaimsPrincipal user)
    {
        Id = id;
        User = user;
    }
}