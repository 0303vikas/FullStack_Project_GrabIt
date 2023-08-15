using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class CartRepository : BaseRepository<Cart>, ICartRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Cart> _cart;
        public CartRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _cart = _context.Carts;
        }
    }
}