using System.Linq.Expressions;
using Domain.Common.Specification;
using Domain.Model;

namespace Domain.Common.Query;

public interface IQueryManager<TEntity> where TEntity: IEntity
{
    IQueryManager<TEntity> ApplySpecification(ISpecification<TEntity>? specification);
    
    Task<TResult?> MapOne<TResult>(Expression<Func<TEntity,TResult>> selectExpression);

    Task<List<TResult>> MapList<TResult>(Expression<Func<TEntity,TResult>> selectExpression);
    
    IQueryable<TEntity> GetQuery();
}