using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IProductService : IBaseService<Product, ProductDto>
    {
        Task<IEnumerable<ProductDto>> GetAllByCategoryId(Guid categoryId);
    }
}