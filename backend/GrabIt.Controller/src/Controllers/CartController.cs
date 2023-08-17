using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    public class CartController : GenericBaseController<Cart, CartReadDto, CartCreateDto, CartUpdateDto>
    {
        private readonly ICartService _baseRepo;
        public CartController(ICartService baseRepo) : base(baseRepo)
        {
            _baseRepo = baseRepo;
        }

        [HttpGet("{userId:Guid}")]
        public override async Task<ActionResult<CartReadDto>> GetOneById(Guid userId)
        {
            return await _baseRepo.GetOneById(userId);
        }
    }
}