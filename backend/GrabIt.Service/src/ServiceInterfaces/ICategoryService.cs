using GrabIt.Core.src.Entities;
using GrabIt.Service.ServiceInterfaces;
using GrabIt.Service.src.Dtos;

namespace GrabIt.Service.src.ServiceInterfaces
{
    public interface ICategoryService : IBaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {

    }
}