using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface ICategoryService : IBaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {

    }
}