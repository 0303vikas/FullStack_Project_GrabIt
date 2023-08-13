using GrabIt.Core.src.Entities;
using GrabIt.Service.src.Dtos;
using GrabIt.Service.src.ServiceInterfaces;

namespace GrabIt.Controller.src.Controllers
{
    public class CategoryController : GenericBaseController<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        public CategoryController(ICategoryService baseRepo) : base(baseRepo)
        {
        }
    }
}