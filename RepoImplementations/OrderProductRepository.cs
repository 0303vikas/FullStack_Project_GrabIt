using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class OrderProductRepository : IOrderProductRepo
    {
        // public bool DeleteOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }

        // public IEnumerable<OrderProduct> GetAll(QueryOptions queryType)
        // {
        //     throw new NotImplementedException();
        // }

        // public OrderProduct GetOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }

        // public OrderProduct UpdateOne(OrderProduct originalData, OrderProduct updateData)
        // {
        //     throw new NotImplementedException();
        // }
        public Task<OrderProduct> CreateOne(OrderProduct createData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderProduct>> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Task<OrderProduct> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderProduct> UpdateOne(OrderProduct originalData, OrderProduct updateData)
        {
            throw new NotImplementedException();
        }
    }
}