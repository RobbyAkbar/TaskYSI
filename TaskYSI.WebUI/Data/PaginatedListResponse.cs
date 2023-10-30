namespace TaskYSI.WebUI.Data;

public class PaginatedListResponse<T>
{
    public IReadOnlyCollection<T> Items { get; set; }
    private int PageNumber { get; set; }
    private int TotalPages { get; set; }
    public int TotalCount { get; set; }
    
    public bool HasPreviousPage { get; set; }

    public bool HasNextPage { get; set; }
}