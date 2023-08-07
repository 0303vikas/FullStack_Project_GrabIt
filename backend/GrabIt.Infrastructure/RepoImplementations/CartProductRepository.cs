using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class CartProductRepository : ICartProductRepo
    {
        public bool DeleteOneById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartProduct> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public CartProduct GetOneById(string id)
        {
            throw new NotImplementedException();
        }

        public CartProduct UpdateOne(CartProduct originalData, CartProduct updateData)
        {
            throw new NotImplementedException();
        }
    }
}