using Domain.Model;
using Domain.Model.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.DB.Interceptors;

public abstract class AbstractReactionInterceptor<TParent,TReaction> : ISaveChangesInterceptor where TParent: IReactionParent<TParent,TReaction> where TReaction : class, IReaction<TParent,TReaction>
{
    public virtual ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        List<EntityEntry<TReaction>> reactions = 
            eventData.Context?.ChangeTracker.Entries<TReaction>().ToList() ?? new List<EntityEntry<TReaction>>().ToList();
        
        if (reactions.Count() == 0)
            return new ValueTask<InterceptionResult<int>>(result);
        
        foreach (EntityEntry<TReaction> entityEntry in reactions)
        {
            ChangePostReactionCountBasedOnReactionEntityState(entityEntry);
        }

        return new ValueTask<InterceptionResult<int>>(result);
    }

    private void ChangePostReactionCountBasedOnReactionEntityState(EntityEntry<TReaction> entry)
    {
        TParent post = entry.Entity.Parent;
        if (entry.State == EntityState.Added)
        {
            post.ReactionCount = post.ReactionCount + 1;
        }

        if (entry.State == EntityState.Deleted)
        {
            if (post.ReactionCount == 0)
            {
                return;
            }
            
            post.ReactionCount = post.ReactionCount - 1;
        }
    }
}