using System.Linq.Expressions;
using Domain.Common.Specification;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.Implementation.Specification;

public class SpecificationHandler<T>: ISpecificationHandler<T> where T: class
{
    public IQueryable<T> Handle(IQueryable<T> query, ISpecification<T>? specification = null)
    {
        if (specification == null)
            return query;

        foreach (Expression<Func<T,bool>> criteria in specification.Criteria)
        {
            query = query.Where(criteria);
        }

        foreach (Expression<Func<T,object>> include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query;
    }
}