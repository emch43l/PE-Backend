using System.Linq.Expressions;
using ApplicationCore.Mapper;

namespace ApplicationCore.Pagination;

public interface IGenericPaginator<TEntity> where TEntity: class
{
    public IGenericPaginator<TEntity> SetPageSize(int pageSize);
    public Task<GenericPaginatorResult<TResult>> Paginate<TResult>(IQueryable<TEntity> query, IMapper<TEntity,TResult> mapper, int pageNumber) where TResult : class;

}