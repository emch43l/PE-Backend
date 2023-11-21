namespace ApplicationCore.Pagination;

public interface IGenericPaginator<TEntity> where TEntity: class
{
    public IGenericPaginator<TEntity> SetPageSize(int PageSize);
    public Task<GenericPaginatorResult<TEntity>> Paginate(IQueryable<TEntity> query, int pageNumber);

}