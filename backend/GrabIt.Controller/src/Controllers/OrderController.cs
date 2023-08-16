using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    public class OrderController : GenericBaseController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IOrderService _orderRepo;
        public OrderController(IOrderService baseRepo) : base(baseRepo)
        {
            _orderRepo = baseRepo;
        }

        [HttpGet("GetOrdersByUserId/userId:Guid")]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrdersByUserId([FromQuery] Guid userId)
        {
            return Ok(await _orderRepo.GetOrdersByUserId(userId));
        }

        [HttpGet("updateOrder/orderId:Guid")]
        public async Task<ActionResult<OrderReadDto>> UpdateOrderStatus([FromQuery] Guid orderId, [FromBody] OrderStatusType orderStatus)
        {
            return Ok(await _orderRepo.UpdateOrderStatus(orderId, orderStatus));
        }
    }
}