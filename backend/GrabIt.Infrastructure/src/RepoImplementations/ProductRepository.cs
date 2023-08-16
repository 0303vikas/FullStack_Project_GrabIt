using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
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
    }
}