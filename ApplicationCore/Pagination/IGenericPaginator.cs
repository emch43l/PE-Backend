using Domain.Model;
using ApplicationCore.Mapper;
using ApplicationCore.Mapper.Base;
using Domain.Common.Query;
using Domain.Model.Interface;

namespace ApplicationCore.Pagination;

public interface IGenericPaginator
{
    public IGenericPaginator SetPageSize(int pageSize);

    public Task<GenericPaginatorResult<TResult>> Paginate<TEntity, TResult>(IQueryable<TEntity> query,
        IMapper<TEntity, TResult> mapper, int pageNumber) where TResult : class where TEntity: IEntity;

}
