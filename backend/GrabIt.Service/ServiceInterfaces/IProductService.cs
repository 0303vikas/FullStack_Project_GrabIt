using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllByCategoryId(string categoryId);
    }
}