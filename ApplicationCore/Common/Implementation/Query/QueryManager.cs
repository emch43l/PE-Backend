using System.Linq.Expressions;
using Domain.Common.Query;
using Domain.Common.Specification;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.Implementation.Query;

public class QueryManager<TEntity> : IQueryManager< TEntity> where TEntity: IEntity
{
    private IQueryable<TEntity> _query;
    private readonly ISpecificationHandler<TEntity> _specificationHandler;

    public QueryManager(IQueryable<TEntity> query)
    {
        _query = query;
    }

    public IQueryManager<TEntity> ApplySpecification(ISpecification<TEntity> specification)
    {
        _query = _specificationHandler.Handle(_query, specification);
        return this;
    }

    public static IQueryManager<TEntity> FromQuery(IQueryable<TEntity> query)
    {
        return new QueryManager<TEntity>(query);
    }

    public Task<TResult?> MapOne<TResult>(Expression<Func<TEntity, TResult>> selectExpression)
    {
        return _query.Select(selectExpression).FirstOrDefaultAsync();
    }

    public Task<List<TResult>> MapList<TResult>(Expression<Func<TEntity, TResult>> selectExpression)
    {
        return _query.Select(selectExpression).ToListAsync();
    }

    public IQueryable<TEntity> GetQuery()
    {
        return _query;
    }
}