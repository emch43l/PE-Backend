using Domain.Model.Base;

namespace Domain.Model.Interface;

public interface IReactionParent<TParent,TReaction> where TParent : IReactionParent<TParent,TReaction>
{
    ICollection<TReaction> Reactions { get; set; }
    
    int ReactionCount { get; set; }
}