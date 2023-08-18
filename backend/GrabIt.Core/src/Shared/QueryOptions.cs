

namespace GrabIt.Core.src.Shared
{
    public class QueryOptions
    {
        public string SearchString { get; set; } = string.Empty;
        public SortMethods Sort { get; set; } = SortMethods.CreatedAt;
        public int PerPage { get; set; } = 9;
        public int PageNumber { get; set; } = 1;

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