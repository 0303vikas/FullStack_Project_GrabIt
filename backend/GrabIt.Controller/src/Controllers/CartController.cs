using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    public class CartController : GenericBaseControllerWithoutGetMethods<Cart, CartReadDto, CartCreateDto, CartUpdateDto>
    {
        private readonly ICartService _baseRepo;
        public CartController(ICartService baseRepo) : base(baseRepo)
        {
            _baseRepo = baseRepo;
        }

        [HttpGet("{userId:Guid}")]
        [Authorize]
        public async Task<ActionResult<CartReadDto>> GetOneByUserId(Guid userId)
        {
            return await _baseRepo.GetOneById(userId);
        }
    }
}