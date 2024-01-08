using System.Linq.Expressions;

namespace Domain.Common.Specification;

public interface ISpecification<T>
{
    List<Expression<Func<T, bool>>> Criteria { get; }
    
    Expression<Func<T, object>>? OrderBy { get; }
    
    Expression<Func<T, object>>? OrderByDescending { get; }

    int? Take { get; }
    
    int? Skip { get; }
    
    List<Expression<Func<T, object>>> Includes { get; }
    
    bool TrackEntities { get; }
    
    bool IsSplitQuery { get; }
    
    void AddOrderBy(Expression<Func<T, object>> expression, bool orderByDescending = false);
    
    void AddCriteria(Expression<Func<T, bool>> criteriaExpression);

    void AddIncludes(Expression<Func<T, object>> include);

    void SetTake(int take);
}