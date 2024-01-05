using Domain.Model.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.DB.Interceptors;

public class CommentReactionInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        List<EntityEntry<CommentReaction>> reactions = 
            eventData.Context?.ChangeTracker.Entries<CommentReaction>().ToList() ?? new List<EntityEntry<CommentReaction>>();
        
        if (reactions.Count() == 0)
            return result;
        
        foreach (EntityEntry<CommentReaction> entityEntry in reactions)
        {
            ChangeCommentReactionCountBasedOnReactionEntityState(entityEntry);   
        }

        return result;
    }

    private void ChangeCommentReactionCountBasedOnReactionEntityState(EntityEntry<CommentReaction> entry)
    {
        Comment comment = entry.Entity.Comment;
        if (entry.State == EntityState.Added)
        {
            comment.ReactionCount = comment.ReactionCount + 1;
        }

        if (entry.State == EntityState.Deleted)
        {
            if(comment.ReactionCount == 0)
            {
                return;
            }
            
            comment.ReactionCount = comment.ReactionCount - 1;
        }
    }
}