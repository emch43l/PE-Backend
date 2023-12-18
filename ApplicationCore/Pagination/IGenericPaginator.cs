using System.Linq.Expressions;

namespace ApplicationCore.Pagination;

public interface IGenericPaginator<TEntity,TResult> where TEntity: class where TResult: class
{
    public IGenericPaginator<TEntity,TResult> SetPageSize(int PageSize);
    public Task<GenericPaginatorResult<TResult>> Paginate(IQueryable<TEntity> query, Expression<Func<TEntity,TResult>> selector, int pageNumber);

}