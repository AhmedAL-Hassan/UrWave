namespace UrWave.Application;

public class BasePagination
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string SearchTerm { get; set; } = string.Empty;

    public string SortColumn { get; set; } = "Name";

    public string SortDirection { get; set; } = "asc";

    public int Skip => (PageNumber - 1) * PageSize;

    public int Take => PageSize;
}