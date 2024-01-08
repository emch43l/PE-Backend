using ApplicationCore.Common.Implementation.Specification.Pagination;
using ApplicationCore.Mapper.Base;
using Domain.Common.Query;
using Domain.Model.Interface;

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
        IQueryManager<TEntity> query,
        IMapper<TEntity, TResult> mapper, 
        int pageNumber) where TResult : class where TEntity : IEntity
    {
        return await Task.Run(async () =>
        {
            int totalItemsCount = query.GetQuery().Count();
            int totalPages = (int)Math.Ceiling((double)totalItemsCount / _itemNumberPerPage);

            int skip = (pageNumber - 1) * _itemNumberPerPage;
            int take = _itemNumberPerPage;

            List<TResult> items = await query
                .ApplySpecification(new PaginatorSpecification<TEntity>(skip,take))
                .GetList(mapper.GetMapperExpression());

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