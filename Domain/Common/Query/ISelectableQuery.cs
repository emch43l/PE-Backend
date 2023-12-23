using System.Linq.Expressions;
using Domain.Model;

namespace Domain.Common.Query;

public interface ISelectableQuery<TEntity> where TEntity: IEntity
{
    Task<TResult?> SelectOne<TResult>(Expression<Func<TEntity,TResult>> selectExpression);

    Task<List<TResult>> SelectList<TResult>(Expression<Func<TEntity,TResult>> selectExpression);
    
    IQueryable<TEntity> GetQuery();
}