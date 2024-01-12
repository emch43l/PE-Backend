using ApplicationCore.Common.Implementation.Specification.Pagination;
using ApplicationCore.Mapper.Base;
using Domain.Model.Interface;
using ApplicationCore.Common.Extension;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Pagination;

public class Paginator : IPaginator
{
    private int _itemNumberPerPage;

    public Paginator(int itemNumberPerPage)
    {
        this.ValidatePageSize(itemNumberPerPage);
        _itemNumberPerPage = itemNumberPerPage;
    }

    public Paginator()
    {
        _itemNumberPerPage = 5;
    }

    public IPaginator SetPageSize(int pageSize)
    {
        this.ValidatePageSize(pageSize);
        _itemNumberPerPage = pageSize;
        return this;
    }

    public async Task<GenericPaginatorResult<TResult>> Paginate<TEntity, TResult>(
        IQueryable<TEntity> query,
        IMapper<TEntity, TResult> mapper, 
        int pageNumber) where TResult : class where TEntity : class, IEntity
    {
        return await Task.Run(async () =>
        {
            int totalItemsCount = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalItemsCount / _itemNumberPerPage);

            int skip = (pageNumber - 1) * _itemNumberPerPage;
            int take = _itemNumberPerPage;

            List<TEntity> items = await query
                .ApplySpecification(new PaginatorSpecification<TEntity>(skip,take))
                .ToListAsync();

            return new GenericPaginatorResult<TResult>(
                totalItemsCount,
                items.Count(),
                mapper.GetMappedResult(items),
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