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
        private readonly DbSet<Order> _payment;
        public OrderRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _payment = _context.Orders;
        }

        public Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderStatus(Guid orderId, OrderStatusType orderStatus)
        {
            throw new NotImplementedException();
        }
    }
}