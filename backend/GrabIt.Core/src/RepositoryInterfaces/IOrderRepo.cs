using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IOrderRepo : IBaseWithCreateMethod<Order>
    {
        IEnumerable<Order> GetOrdersByUserId(string id);
        Order UpdateOrderStatus(string id, OrderStatusType orderStatus);
        bool CancelOrder(string id);
    }
}