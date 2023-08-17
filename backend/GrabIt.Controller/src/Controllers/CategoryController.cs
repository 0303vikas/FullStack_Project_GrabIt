using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    public class CategoryController : GenericBaseController<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        public CategoryController(ICategoryService baseRepo) : base(baseRepo)
        {
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid id)
        {
            var result = await base.DeleteOneById(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<CategoryReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] CategoryUpdateDto updateData)
        {
            var result = await base.UpdateOneById(id, updateData);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<CategoryReadDto>> CreateOne([FromBody] CategoryCreateDto createData)
        {
            var result = await base.CreateOne(createData);
            return Ok(result);
        }
    }
}