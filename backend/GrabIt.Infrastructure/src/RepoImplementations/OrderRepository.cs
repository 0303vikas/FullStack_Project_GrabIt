using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using GrabIt.Infrastructure.src.Shared;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Order> _orders;
        public OrderRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _orders = _context.Orders;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId)
        {
            return await _orders.Where(o => o.UserId == userId).Include(e => e.Address).Include(e => e.OrderProducts).ToListAsync();
        }

        public async Task<Order> UpdateOrderStatus(Guid orderId, OrderStatusType orderStatus)
        {
            var author = await _orders.FindAsync(orderId);
            if (author == null)
            {
                throw new Exception("Order not found");
            }
            author.Status = orderStatus;
            await _context.SaveChangesAsync();
            return author;
        }

        public override async Task<IEnumerable<Order>> GetAll(QueryOptions queryType)
        {
            IQueryable<Order> queryBuilder = _orders.Include(e => e.Address).Include(e => e.OrderProducts);

            // sorting
            switch (queryType.Sort)
            {
                case SortMethods.Asc:
                    queryBuilder = queryBuilder.OrderBy(e => e.Status);
                    break;
                case SortMethods.Desc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.Status);
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
            return await Pagination<Order>.CreateAsync(queryBuilder.AsNoTracking(), queryType.PageNumber, queryType.PerPage);
        }
    }
}