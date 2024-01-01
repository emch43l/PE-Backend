using Domain.Model;

namespace Domain.Common.Specification;

public interface ISpecificationHandler<T> where T: IEntity
{
    public IQueryable<T> Handle(IQueryable<T> query, ISpecification<T>? specification);
}