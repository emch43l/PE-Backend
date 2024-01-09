﻿using Domain.Common.Specification;
using Domain.Model;
using Domain.Model.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.Extension;

public static class QuerySpecificationExtension
{
    public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> query, ISpecification<T>? specification = null) where T: class, IEntity
    {
        if (specification == null)
            return query;
        
        if (specification.OrderByDescending != null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }
        else if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
        }

        if (!specification.TrackEntities)
        {
            query = query.AsNoTracking();
        }

        if (specification.Take != null)
        {
            query = query.Take((int)specification.Take);
        }

        if (specification.Skip != null)
        {
            query = query.Skip((int)specification.Skip);
        }
        
        query = specification.Criteria
            .Aggregate(query, 
                (current, criteria) => current.Where(criteria)
            );

        // for expressions
        query = specification.IncludesExpressions
            .Aggregate(query, 
                (current, include) => current.Include(include)
            );
        // for strings
        query = specification.IncludesStrings
            .Aggregate(query, 
                (current, include) => current.Include(include)
            );


        return query;
    }
}