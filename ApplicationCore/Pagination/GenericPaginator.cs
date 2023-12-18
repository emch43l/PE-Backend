using System.Linq.Expressions;

namespace ApplicationCore.Pagination;

public class GenericPaginator<TEntity,TResult> : IGenericPaginator<TEntity,TResult> where TEntity : class where TResult: class
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

    public IGenericPaginator<TEntity,TResult> SetPageSize(int PageSize)
    {
        this.ValidatePageSize(PageSize);
        _itemNumberPerPage = PageSize;
        return this;
    }

    public async Task<GenericPaginatorResult<TResult>> Paginate(IQueryable<TEntity> query, Expression<Func<TEntity,TResult>> selector, int pageNumber)
    {
        return await Task.Run(() =>
        {
            int totalItemsCount = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalItemsCount / _itemNumberPerPage);

            List<TResult> items = query
                .Skip((pageNumber - 1) * _itemNumberPerPage)
                .Take(_itemNumberPerPage)
                .Select(selector)
                .ToList();

            return new GenericPaginatorResult<TResult>(
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