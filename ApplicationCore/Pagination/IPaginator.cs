using ApplicationCore.Mapper.Base;
using Domain.Model.Interface;

namespace ApplicationCore.Pagination;

public interface IPaginator
{
    IPaginator SetPageSize(int pageSize);

    Task<GenericPaginatorResult<TResult>> Paginate<TEntity, TResult>(
        IQueryable<TEntity> query,
        IMapper<TEntity, TResult> mapper, 
        int pageNumber
        ) where TResult : class where TEntity: class, IEntity;

}
