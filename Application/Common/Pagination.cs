namespace Application.Common;

public class Pagination
{ 
    public int Page { get; set; }
    public int PageSize { get; set; }
    
    public void Deconstruct(out int page, out int pageSize) => (page, pageSize) = (Page, PageSize);
}