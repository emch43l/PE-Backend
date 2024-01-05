using System.Security.Claims;
using Domain.Enum;

namespace ApplicationCore.CQRS.CommentOperations.Command;

public class AddReactionToCommentCommand : ICommand
{
    public Guid CommentId { get; set; }
    
    public ReactionTypeEnum Reaction { get; set; }
    
    public ClaimsPrincipal User { get; set; }
    
    public AddReactionToCommentCommand(Guid commentId, ReactionTypeEnum reaction, ClaimsPrincipal user)
    {
        CommentId = commentId;
        Reaction = reaction;
        User = user;
    }
}