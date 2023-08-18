using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class CartProductRepository : BaseRepository<CartProduct>, ICartProductRepo
    {
        public CartProductRepository(DatabaseContext context) : base(context) { }
    }
}