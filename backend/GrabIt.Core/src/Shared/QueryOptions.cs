

namespace GrabIt.Core.src.Shared
{
    public class QueryOptions
    {
        public string SearchString { get; set; } = string.Empty;
        public SortMethods Sort { get; set; } = SortMethods.CreatedAt;
        public int PerPage { get; set; } = 0;
        public int PageNumber { get; set; } = 0;

    }

    public enum SortMethods
    {
        Asc,
        Desc,
        UpdatedAt,
        UpdatedAtDesc,
        CreatedAt,
        CreatedAtDesc,
    }
}