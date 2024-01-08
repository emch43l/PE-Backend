using Domain.Common.Specification.Base;
using Domain.Model.Interface;

namespace ApplicationCore.Common.Implementation.Specification.Pagination;

public class PaginatorSpecification<TEntity> : SpecificationBase<TEntity> where TEntity: IEntity
{
    public PaginatorSpecification(int skip, int take)
    {
        SetTake(take);
        SetSkip(skip);
    }
}