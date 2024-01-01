using System.Linq.Expressions;

namespace Domain.Common.Specification;

public interface ISpecification<T>
{
    HashSet<Expression<Func<T, bool>>> Criteria { get; }
    
    Dictionary<Expression<Func<T, object>>, bool> OrderBy { get; }
    
    ISpecification<T> AddOrderBy(Expression<Func<T, object>> expression, bool orderByDescending = false);
    
    ISpecification<T> AddCriteria(Expression<Func<T, bool>> criteriaExpression);
}