namespace Tuto_8.Models;

public class PaginatedList<T> where T : class
{
    public int PageNum { get; set; }
    public int PageSize { get; set; }
    public int AllPages { get; set; }
    public List<T> Trips { get; set; } 

    public PaginatedList()
    {
        Trips = new List<T>();
    }
}
