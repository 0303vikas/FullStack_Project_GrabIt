using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IOrderService : IBaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        Task<IEnumerable<OrderReadDto>> GetOrdersByUserId(Guid id);
        Task<OrderReadDto> UpdateOrderStatus(Guid id, OrderStatusType orderStatus);
    }
}