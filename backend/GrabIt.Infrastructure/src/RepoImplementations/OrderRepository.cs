using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
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
            return await _orders.Where(o => o.UserId == userId).ToListAsync();
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
    }
}