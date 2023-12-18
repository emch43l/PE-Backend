namespace Domain.Common.Specification;

public interface ISpecificationHandler<T> where T: class
{
    public IQueryable<T> Handle(IQueryable<T> query, ISpecification<T>? specification);
}