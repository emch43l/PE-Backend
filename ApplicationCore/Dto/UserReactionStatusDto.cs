using Domain.Enum;

namespace ApplicationCore.Dto;

public class UserReactionStatusDto
{
    public bool AlreadyReacted { get; set; }
    
    public ReactionTypeEnum? Reaction { get; set; }
}