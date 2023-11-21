namespace ApplicationCore.Pagination;

public class GenericPaginator<TEntity> : IGenericPaginator<TEntity> where TEntity : class
{
    private int _itemNumberPerPage;

    public GenericPaginator(int itemNumberPerPage)
    {
        this.ValidatePageSize(itemNumberPerPage);
        _itemNumberPerPage = itemNumberPerPage;
    }

    public GenericPaginator()
    {
        _itemNumberPerPage = 5;
    }

    public IGenericPaginator<TEntity> SetPageSize(int PageSize)
    {
        this.ValidatePageSize(PageSize);
        _itemNumberPerPage = PageSize;
        return this;
    }

    public async Task<GenericPaginatorResult<TEntity>> Paginate(IQueryable<TEntity> query, int pageNumber)
    {
        return await Task.Run(() =>
        {
            int totalItemsCount = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalItemsCount / _itemNumberPerPage);

            List<TEntity> items = query
                .Skip((pageNumber - 1) * _itemNumberPerPage)
                .Take(_itemNumberPerPage)
                .ToList();

            return new GenericPaginatorResult<TEntity>(
                totalItemsCount,
                items.Count(),
                items,
                pageNumber,
                totalPages
            );
        });
    }

    private void ValidatePageSize(int PageSize)
    {
        if (PageSize < 1)
            throw new ArgumentException($"{nameof(PageSize)} cannot be less than 1");
    }
}