using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    public class ProductController : GenericBaseController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        private readonly IProductService _baseRepo;
        public ProductController(IProductService baseRepo) : base(baseRepo)
        {
            _baseRepo = baseRepo;
        }
        [HttpGet("category/{categoryId:Guid}")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllByCategoryId([FromQuery] Guid categoryId)
        {
            return Ok(await _baseRepo.GetAllByCategoryId(categoryId));
        }
    }


}