using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class CartRepository : ICartRepo
    {
        // public bool DeleteOneByUserId(string userId)
        // {
        //     throw new NotImplementedException();
        // }

        // public Cart GetOneByUserId(string userId)
        // {
        //     throw new NotImplementedException();
        // }
        public Task<Cart> CreateOne(Cart createData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> UpdateOne(Cart originalData, Cart updateData)
        {
            throw new NotImplementedException();
        }
    }
}