using System.Linq.Expressions;
using Domain.Common.Specification;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification;

public class SpecificationHandler<T>: ISpecificationHandler<T> where T: IEntity
{
    public IQueryable<T> Handle(IQueryable<T> query, ISpecification<T>? specification = null)
    {
        if (specification == null)
            return query;

        foreach (Expression<Func<T,bool>> criteria in specification.Criteria)
        {
            query = query.Where(criteria);
        }

        foreach (KeyValuePair<Expression<Func<T, object>>, bool> valuePair in specification.OrderBy)
        {
            if (valuePair.Value)
            {
                query = query.OrderByDescending(valuePair.Key);
            }
            else
            {
                query = query.OrderBy(valuePair.Key);
            }
        }

        return query;
    }
}