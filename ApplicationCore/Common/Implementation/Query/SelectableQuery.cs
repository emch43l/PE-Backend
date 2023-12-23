using System.Linq.Expressions;
using Domain.Common.Query;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.Implementation.Query;

public class SelectableQuery<TEntity> : ISelectableQuery< TEntity> where TEntity: IEntity
{
    private readonly IQueryable<TEntity> _query;

    public SelectableQuery(IQueryable<TEntity> query)
    {
        _query = query;
    }

    public static ISelectableQuery<TEntity> FromQuery(IQueryable<TEntity> query)
    {
        return new SelectableQuery<TEntity>(query);
    }

    public Task<TResult?> SelectOne<TResult>(Expression<Func<TEntity, TResult>> selectExpression)
    {
        return _query.Select(selectExpression).FirstOrDefaultAsync();
    }

    public Task<List<TResult>> SelectList<TResult>(Expression<Func<TEntity, TResult>> selectExpression)
    {
        return _query.Select(selectExpression).ToListAsync();
    }

    public IQueryable<TEntity> GetQuery()
    {
        return _query;
    }
}