using GrabIt.Core.src.Entities;
using GrabIt.Core.src.Shared;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    public class OrderProductController : GenericBaseController<OrderProduct, OrderProductReadDto, OrderProductCreateDto, OrderProductUpdateDto>
    {
        public OrderProductController(IOrderProductService baseRepo) : base(baseRepo)
        {
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<OrderProductReadDto>> GetOneById(Guid id)
        {
            return await base.GetOneById(id);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<IEnumerable<OrderProductReadDto>>> GetAll([FromQuery] QueryOptions options)
        {
            return await base.GetAll(options);
        }
    }
}