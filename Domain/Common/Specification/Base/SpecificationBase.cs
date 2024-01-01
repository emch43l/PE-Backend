using System.Linq.Expressions;
using Domain.Model;

namespace Domain.Common.Specification.Base;

public class SpecificationBase<TEntity> : ISpecification<TEntity> where TEntity: IEntity
{
    public HashSet<Expression<Func<TEntity, bool>>> Criteria { get; } = new();
    public Dictionary<Expression<Func<TEntity, object>>, bool> OrderBy { get; private set; } = new ();
    public ISpecification<TEntity> AddOrderBy(Expression<Func<TEntity, object>> expression, bool orderByDescending = false)
    {
        OrderBy.Add(expression,orderByDescending);
        return this;
    }

    public ISpecification<TEntity> AddCriteria(Expression<Func<TEntity, bool>> criteriaExpression)
    {
        Criteria.Add(criteriaExpression);
        return this;
    }
    
}