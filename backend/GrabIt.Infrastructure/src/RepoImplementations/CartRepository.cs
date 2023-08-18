using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class CartRepository : BaseRepository<Cart>, ICartRepo
    {
        public CartRepository(DatabaseContext context) : base(context) { }
    }
}