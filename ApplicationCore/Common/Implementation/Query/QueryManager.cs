using System.Linq.Expressions;
using ApplicationCore.Common.Extension;
using Domain.Common.Query;
using Domain.Common.Specification;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.Implementation.Query;

public class QueryManager<TEntity> : IQueryManager< TEntity> where TEntity: class, IEntity
{
    private IQueryable<TEntity> _query;

    public QueryManager(IQueryable<TEntity> query)
    {
        _query = query;
    }

    public IQueryManager<TEntity> ApplySpecification(ISpecification<TEntity>? specification)
    {
        _query = _query.ApplySpecification(specification);
        return this;
    }

    public static IQueryManager<TEntity> FromQuery(IQueryable<TEntity> query)
    {
        return new QueryManager<TEntity>(query);
    }

    public Task<TResult?> GetOne<TResult>(Expression<Func<TEntity, TResult>> selectExpression)
    {
        return _query.Select(selectExpression).FirstOrDefaultAsync();
    }

    public Task<List<TResult>> GetList<TResult>(Expression<Func<TEntity, TResult>> selectExpression)
    {
        return _query.Select(selectExpression).ToListAsync();
    }

    public IQueryable<TEntity> GetQuery()
    {
        return _query;
    }
}