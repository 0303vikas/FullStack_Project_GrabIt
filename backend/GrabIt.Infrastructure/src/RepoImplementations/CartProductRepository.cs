using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class CartProductRepository : BaseRepository<CartProduct>, ICartProductRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<CartProduct> _cartProducts;
        public CartProductRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _cartProducts = _context.CartProducts;
        }
    }
}