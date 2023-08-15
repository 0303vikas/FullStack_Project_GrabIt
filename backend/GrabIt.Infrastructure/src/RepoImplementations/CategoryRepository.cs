using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
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
    }
}