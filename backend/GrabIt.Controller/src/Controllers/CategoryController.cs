using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Controller.src.Controllers
{
    public class CategoryController : GenericBaseController<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        public CategoryController(ICategoryService baseRepo) : base(baseRepo)
        {
        }
    }
}