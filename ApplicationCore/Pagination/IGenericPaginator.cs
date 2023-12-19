using System.Linq.Expressions;
using ApplicationCore.Mapper;

namespace ApplicationCore.Pagination;

public interface IGenericPaginator<TEntity,TResult> where TEntity: class where TResult: class
{
    public IGenericPaginator<TEntity,TResult> SetPageSize(int pageSize);
    public Task<GenericPaginatorResult<TResult>> Paginate(IQueryable<TEntity> query, IMapper<TEntity,TResult> mapper, int pageNumber);

}