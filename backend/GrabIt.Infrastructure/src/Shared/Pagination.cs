using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.src.Shared
{
    public class Pagination<T> : List<T>
    {
        public int PageNumber { get; private set; }
        public int TotalPage { get; private set; }

        public Pagination(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPage;
        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new Pagination<T>(items, count, pageNumber, pageSize);
        }

    }
}