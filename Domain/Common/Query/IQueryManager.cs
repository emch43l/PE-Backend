using System.Linq.Expressions;
using Domain.Common.Specification;
using Domain.Model.Interface;

namespace Domain.Common.Query;

public interface IQueryManager<TEntity> where TEntity: IEntity
{
    IQueryManager<TEntity> ApplySpecification(ISpecification<TEntity>? specification);
    
    Task<TResult?> GetOne<TResult>(Expression<Func<TEntity,TResult>> selectExpression);

    Task<List<TResult>> GetList<TResult>(Expression<Func<TEntity,TResult>> selectExpression);
    
    IQueryable<TEntity> GetQuery();
}