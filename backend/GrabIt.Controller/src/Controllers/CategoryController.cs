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
        public override async Task<ActionResult> DeleteOneById([FromRoute] Guid id)
        {
            return await base.DeleteOneById(id);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<CategoryReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] CategoryUpdateDto updateData)
        {
            return await base.UpdateOneById(id, updateData);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<CategoryReadDto>> CreateOne([FromBody] CategoryCreateDto createData)
        {
            return await base.CreateOne(createData);
        }
    }
}