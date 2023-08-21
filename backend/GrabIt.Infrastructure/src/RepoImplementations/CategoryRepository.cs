using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using GrabIt.Infrastructure.src.Shared;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Category> _category;
        public CategoryRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _category = _context.Categories;
        }

        public override async Task<IEnumerable<Category>> GetAll(QueryOptions queryType)
        {
            IQueryable<Category> queryBuilder = _category;
            // check search string
            if (!string.IsNullOrEmpty(queryType.SearchString))
            {
                queryBuilder = queryBuilder.Where(e => e.Name.Contains(queryType.SearchString));
            }

            //  sorting 
            switch (queryType.Sort)
            {
                case SortMethods.Asc:
                    queryBuilder = queryBuilder.OrderBy(e => e.Name);
                    break;
                case SortMethods.Desc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.Name);
                    break;
                case SortMethods.UpdatedAt:
                    queryBuilder = queryBuilder.OrderBy(e => e.UpdatedAt);
                    break;
                case SortMethods.CreatedAt:
                    queryBuilder = queryBuilder.OrderBy(e => e.CreatedAt);
                    break;
                case SortMethods.UpdatedAtDesc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.UpdatedAt);
                    break;
                case SortMethods.CreatedAtDesc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.CreatedAt);
                    break;
                default:
                    queryBuilder = queryBuilder.OrderBy(e => e.CreatedAt);
                    break;
            }

            return await Pagination<Category>.CreateAsync(queryBuilder.AsNoTracking(), queryType.PageNumber, queryType.PerPage);
        }
    }
}