using System.Linq.Expressions;

namespace Domain.Common.Specification;

public interface ISpecification<T>
{
    HashSet<Expression<Func<T, bool>>> Criteria { get; }
    HashSet<Expression<Func<T, object>>> Includes { get; }
    
    Expression<Func<T, object>>? OrderBy { get; }
    Expression<Func<T, object>>? OrderByDescending { get; }
    
    public ISpecification<T> AddCriteria(Expression<Func<T, bool>> criteriaExpression);
    public ISpecification<T> AddInclude(Expression<Func<T, object>> includeExpression);
}