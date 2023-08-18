using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using GrabIt.Infrastructure.src.Shared;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProductRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<OrderProduct> _orderProduct;

        public OrderProductRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _orderProduct = _context.OrderProducts;
        }

        public override async Task<IEnumerable<OrderProduct>> GetAll(QueryOptions queryType)
        {
            IQueryable<OrderProduct> queryBuilder = _orderProduct;
            // check search string
            if (!string.IsNullOrEmpty(queryType.SearchString))
            {
                queryBuilder = queryBuilder.Where(e => e.Product.Title.Contains(queryType.SearchString));
            }

            // sorting
            switch (queryType.Sort)
            {
                case SortMethods.Asc:
                    queryBuilder = queryBuilder.OrderBy(e => e.Product.Title);
                    break;
                case SortMethods.Desc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.Product.Title);
                    break;
                case SortMethods.UpdatedAt:
                    queryBuilder = queryBuilder.OrderBy(e => e.Order.UpdatedAt);
                    break;
                case SortMethods.CreatedAt:
                    queryBuilder = queryBuilder.OrderBy(e => e.Order.CreatedAt);
                    break;
                case SortMethods.UpdatedAtDesc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.Order.UpdatedAt);
                    break;
                case SortMethods.CreatedAtDesc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.Order.CreatedAt);
                    break;
                default:
                    queryBuilder = queryBuilder.OrderBy(e => e.Order.CreatedAt);
                    break;
            }
            return await Pagination<OrderProduct>.CreateAsync(queryBuilder, queryType.PageNumber, queryType.PerPage);
        }
    }
}