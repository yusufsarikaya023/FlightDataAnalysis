namespace Application.Common;

public class Pagination
{
    public Pagination()
    {
    }

    public Pagination(int page, int pageSize) => (Page, PageSize) = (page, pageSize);
    public int Page { get; set; }
    public int PageSize { get; set; }

    public void Deconstruct(out int page, out int pageSize) => (page, pageSize) = (Page, PageSize);
}