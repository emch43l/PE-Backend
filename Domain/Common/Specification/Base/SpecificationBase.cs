using System.Linq.Expressions;
using Domain.Model;

namespace Domain.Common.Specification.Base;

public class SpecificationBase<TEntity> : ISpecification<TEntity> where TEntity: IEntity
{
    public HashSet<Expression<Func<TEntity, bool>>> Criteria { get; } = new();
    public HashSet<Expression<Func<TEntity, object>>> Includes { get; } = new();
    public Expression<Func<TEntity, object>>? OrderBy { get; } = null;
    public Expression<Func<TEntity, object>>? OrderByDescending { get; } = null;
    public ISpecification<TEntity> AddCriteria(Expression<Func<TEntity, bool>> criteriaExpression)
    {
        Criteria.Add(criteriaExpression);
        return this;
    }

    public ISpecification<TEntity> AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        Includes.Add(includeExpression);
        return this;
    }
}