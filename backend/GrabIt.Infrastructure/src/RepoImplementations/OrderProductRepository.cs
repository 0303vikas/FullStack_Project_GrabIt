using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
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
    }
}