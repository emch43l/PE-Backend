namespace ApplicationCore.Pagination;

public interface IGenericPaginatorResult<T> where T: class
{
     int TotalItems { get; }
    int ItemsOnPage { get; }
    List<T> Items { get; set; }
    int CurrentPage { get; }
    int TotalPages { get; }
}