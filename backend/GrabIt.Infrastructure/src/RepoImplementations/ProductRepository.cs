using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using GrabIt.Infrastructure.src.Shared;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Product> _products;
        public ProductRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _products = _context.Products;
        }

        public async Task<IEnumerable<Product>> GetAllByCategoryId(Guid categoryId)
        {
            return await _products.Where(e => e.CategoryId == categoryId).ToListAsync();
        }

        public override async Task<IEnumerable<Product>> GetAll(QueryOptions queryType)
        {
            IQueryable<Product> queryBuilder = _products;
            // check search string
            if (!string.IsNullOrEmpty(queryType.SearchString))
            {
                queryBuilder = queryBuilder.Where(e => e.Title.Contains(queryType.SearchString) || e.Description.Contains(queryType.SearchString));
            }

            //  sorting 
            switch (queryType.Sort)
            {
                case SortMethods.Asc:
                    queryBuilder = queryBuilder.OrderBy(e => e.Title);
                    break;
                case SortMethods.Desc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.Title);
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
            return await Pagination<Product>.CreateAsync(queryBuilder.AsNoTracking(), queryType.PageNumber, queryType.PerPage);
        }
    }
}