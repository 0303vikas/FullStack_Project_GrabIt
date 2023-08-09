
using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IProductRepo : IBaseWithCreateMethod<Product>
    {
        Task<IEnumerable<Product>> GetAllByCategoryId(string categoryId);
    }
}