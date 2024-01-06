using Domain.Model.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.DB.Interceptors.Reaction;

public abstract class AbstractReactionInterceptor<TParent,TReaction> : ISaveChangesInterceptor where TParent: IReactionParent<TParent,TReaction> where TReaction : class, IReaction<TParent,TReaction>
{
    public virtual ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        List<EntityEntry<TReaction>> reactions = 
            eventData.Context?.ChangeTracker.Entries<TReaction>().ToList() ?? new List<EntityEntry<TReaction>>().ToList();
        
        if (reactions.Count() == 0)
            return new ValueTask<InterceptionResult<int>>(result);
        
        reactions.ForEach(entry => AdjustReactionCount(entry));
        

        return new ValueTask<InterceptionResult<int>>(result);
    }

    private void AdjustReactionCount(EntityEntry<TReaction> entry)
    {
        TParent parent = entry.Entity.Parent;
        if (entry.State == EntityState.Added)
        {
            parent.ReactionCount = parent.ReactionCount + 1;
        }

        if (entry.State == EntityState.Deleted)
        {
            if (parent.ReactionCount == 0)
            {
                return;
            }
            
            parent.ReactionCount = parent.ReactionCount - 1;
        }
    }
}