using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllByCategoryId([FromRoute] Guid categoryId)
        {
            return Ok(await _baseRepo.GetAllByCategoryId(categoryId));
        }


        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid id)
        {
            return Ok(await _baseRepo.DeleteOneById(id));
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<ProductReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] ProductUpdateDto updateData)
        {

            return Ok(await _baseRepo.UpdateOneById(id, updateData));
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<ProductReadDto>> CreateOne([FromBody] ProductCreateDto createData)
        {
            return Ok(await _baseRepo.CreateOne(createData));
        }
    }


}