namespace Application.Common;

public class Pagination
{
    public Pagination()
    {
    }

    /// <summary>
    /// Default constructor that initializes the page to 1 and page size to 10.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    public Pagination(int page, int pageSize) => (Page, PageSize) = (page, pageSize);
    
    /// <summary>
    /// Default constructor that initializes the page to 1.
    /// </summary>
    public int Page { get; set; }
    
    /// <summary>
    /// Default constructor that initializes the page size to 10.
    /// </summary>
    public int PageSize { get; set; }

    public void Deconstruct(out int page, out int pageSize) => (page, pageSize) = (Page, PageSize);
}