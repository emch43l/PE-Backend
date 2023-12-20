using System.Linq.Expressions;
using ApplicationCore.Mapper;

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

    public IGenericPaginator<TEntity> SetPageSize(int pageSize)
    {
        this.ValidatePageSize(pageSize);
        _itemNumberPerPage = pageSize;
        return this;
    }

    public async Task<GenericPaginatorResult<TResult>> Paginate<TResult>(IQueryable<TEntity> query, IMapper<TEntity,TResult> mapper, int pageNumber) where TResult : class
    {
        return await Task.Run(() =>
        {
            int totalItemsCount = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalItemsCount / _itemNumberPerPage);

            List<TResult> items = query
                .Skip((pageNumber - 1) * _itemNumberPerPage)
                .Take(_itemNumberPerPage)
                .Select(mapper.GetMapperExpression())
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

    private void ValidatePageSize(int pageSize)
    {
        if (pageSize < 1)
            throw new ArgumentException($"{nameof(pageSize)} cannot be less than 1");
    }
}