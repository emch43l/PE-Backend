using System.Linq.Expressions;
using Domain.Model;

namespace Domain.Common.Specification.Base;

public class SpecificationBase<TEntity> : ISpecification<TEntity> where TEntity: IEntity
{
    public List<Expression<Func<TEntity, bool>>> Criteria { get; } = new();
    public Expression<Func<TEntity, object>>? OrderBy { get; private set; } = null;

    public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; } = null;

    public int? Take { get; private set; } = null;

    public List<string> Includes { get; set; } = new();

    public bool TrackEntities { get; private set; } = true;

    public bool IsSplitQuery { get; private set; } = false;

    public void AddOrderBy(Expression<Func<TEntity, object>> expression, bool orderByDescending = false)
    {
        if (orderByDescending)
        {
            OrderByDescending = expression;
        }
        else
        {
            OrderBy = expression;
        }
    }

    public void AddCriteria(Expression<Func<TEntity, bool>> criteriaExpression)
    {
        Criteria.Add(criteriaExpression);
    }
    
    public void AddIncludes(string include)
    {
        Includes.Add(include);
    }

    public void SetTake(int take)
    {
        Take = take;
    }
    
    public void SetEntityTracking(bool track = true)
    {
        TrackEntities = track;
    }

    public void SplitQuery()
    {
        IsSplitQuery = true;
    }

}