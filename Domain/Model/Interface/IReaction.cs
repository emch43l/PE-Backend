using Domain.Enum;

namespace Domain.Model.Interface;

public interface IReaction<TParent,TReaction> where TParent: IReactionParent<TParent,TReaction>
{
    TParent Parent { get; set; }
    
    ReactionTypeEnum ReactionType { get; set; }
    
    DateTime Date { get; set; }
}
