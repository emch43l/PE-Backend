namespace ApplicationCore.Pagination;

public record GenericPaginatorResult<T>: IGenericPaginatorResult<T> where T: class
{
    public int TotalItems { get; }
    public int ItemsOnPage { get; }
    public List<T> Items { get; set; }
    public int CurrentPage { get; }
    public int TotalPages { get; }

    public GenericPaginatorResult(int totalResults, int currentResultNumber, List<T> items, int currentPage, int totalPages)
    {
        TotalItems = totalResults;
        ItemsOnPage = currentResultNumber;
        Items = items;
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }

}