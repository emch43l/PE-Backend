using Domain.Model.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.DB.Interceptors.Rating;

public abstract class AbstractRatingInterceptor<TParent,TRating> : ISaveChangesInterceptor where TParent: IRatingParent<TParent,TRating> where TRating : class, IRating<TParent,TRating>
{
    public virtual ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        List<EntityEntry<TRating>> reactions = 
            eventData.Context?.ChangeTracker.Entries<TRating>().ToList() ?? new List<EntityEntry<TRating>>().ToList();
        
        if (reactions.Count() == 0)
            return new ValueTask<InterceptionResult<int>>(result);
        
        reactions.ForEach(entry => AdjustParentRating(entry));

        return new ValueTask<InterceptionResult<int>>(result);
    }

    private void AdjustParentRating(EntityEntry<TRating> entry)
    {
        TParent parent = entry.Entity.Parent;
        TRating entity = entry.Entity;
        
        double averageRatingNumber = parent.AverageRating;
        int ratingVotesCount = parent.NumberOfRatingVotes;
        
        if (entry.State == EntityState.Added)
        {
            averageRatingNumber = 
                (averageRatingNumber * ratingVotesCount + (int)entity.Raintg) / ++ratingVotesCount;
        }

        if (entry.State == EntityState.Deleted)
        {
            averageRatingNumber = 
                (averageRatingNumber * ratingVotesCount - (int)entity.Raintg) / --ratingVotesCount;
        }

        parent.AverageRating = averageRatingNumber;
        parent.NumberOfRatingVotes = ratingVotesCount;
    }
}