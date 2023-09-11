using GrabIt.Core.src.Entities;
using GrabIt.Core.src.Shared;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetOrdersByUserId/{userId:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrdersByUserId([FromRoute] Guid userId)
        {
            return Ok(await _orderRepo.GetOrdersByUserId(userId));
        }

        [HttpGet("updateOrder/{orderId:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<OrderReadDto>> UpdateOrderStatus([FromRoute] Guid orderId, [FromBody] OrderStatusType orderStatus)
        {
            return Ok(await _orderRepo.UpdateOrderStatus(orderId, orderStatus));
        }

        [Authorize]
        public override async Task<ActionResult<OrderReadDto>> CreateOne([FromBody] OrderCreateDto createData)
        {
            return await base.CreateOne(createData);
        }

        [Authorize(Policy = "OrderOwnerOnly")]
        public override async Task<ActionResult> DeleteOneById([FromRoute] Guid id)
        {
            return await base.DeleteOneById(id);
        }

        [Authorize(Roles = "Admin")]
        public override Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll([FromQuery] QueryOptions options)
        {
            return base.GetAll(options);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<OrderReadDto>> GetOneById([FromRoute] Guid id)
        {
            return await base.GetOneById(id);
        }

        [Authorize(Policy = "OrderOwnerOnly")]
        public override async Task<ActionResult<OrderReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] OrderUpdateDto updateData)
        {
            return await base.UpdateOneById(id, updateData);
        }
    }
}