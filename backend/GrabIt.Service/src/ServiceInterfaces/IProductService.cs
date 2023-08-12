using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IProductService : IBaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        Task<IEnumerable<ProductReadDto>> GetAllByCategoryId(Guid categoryId);
    }
}