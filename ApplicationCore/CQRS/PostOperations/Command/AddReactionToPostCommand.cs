using System.Security.Claims;
using Domain.Enum;

namespace ApplicationCore.CQRS.PostOperations.Command;

public class AddReactionToPostCommand : ICommand
{
    public Guid PostId { get; set; }
    
    public ReactionTypeEnum Reaction { get; set; }
    
    public ClaimsPrincipal User { get; set; }
    
    public AddReactionToPostCommand(Guid postId, ReactionTypeEnum reaction, ClaimsPrincipal user)
    {
        PostId = postId;
        Reaction = reaction;
        User = user;
    }

    
}