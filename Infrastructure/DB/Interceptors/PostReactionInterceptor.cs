using System.Data.Common;
using Domain.Model.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.DB.Interceptors;

public class PostReactionInterceptor : ISaveChangesInterceptor
{
    public ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        List<EntityEntry<PostReaction>> reactions = 
            eventData.Context?.ChangeTracker.Entries<PostReaction>().ToList() ?? new List<EntityEntry<PostReaction>>().ToList();
        
        if (reactions.Count() == 0)
            return new ValueTask<InterceptionResult<int>>(result);
        
        foreach (EntityEntry<PostReaction> entityEntry in reactions)
        {
            ChangePostReactionCountBasedOnReactionEntityState(entityEntry);
        }

        return new ValueTask<InterceptionResult<int>>(result);
    }

    private void ChangePostReactionCountBasedOnReactionEntityState(EntityEntry<PostReaction> entry)
    {
        Post post = entry.Entity.Post;
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