using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class OrderRepository : IOrderRepo
    {
        public bool CancelOrder(string id)
        {
            throw new NotImplementedException();
        }

        public Order CreateOne(Order createData)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOneById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Order GetOneById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOne(Order originalData, Order updateData)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrderStatus(string id, OrderStatusType orderStatus)
        {
            throw new NotImplementedException();
        }
    }
}