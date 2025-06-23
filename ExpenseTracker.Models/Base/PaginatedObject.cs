using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models.Base;

public class PaginatedObject<T> : List<T>
{
    public IEnumerable<T>? Data { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int? TotalCount { get; set; } = 0;
    public int? TotalPage { get; set; }

    public PaginatedObject(IEnumerable<T> data, int page, int pageSize, int totalCount, int totalPage)
    {

        Data = data;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
        TotalPage = totalPage;
        AddRange(Data);

    }

    public PaginatedObject()
    {
    }

    public static async Task<PaginatedObject<T>> GetPagedListAsync(IQueryable<T> data, int page, int pageSize)
    {

        var count = data.Count();
        Console.WriteLine(count);
        var totalPage = (int)Math.Ceiling((decimal?)count! / pageSize! ?? 0);
        var items = await data.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedObject<T>(items, page, pageSize, count, totalPage);
    }
}
