
using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IProductRepo : IBaseWithCreateMethod<Product>
    {
        IEnumerable<Product> GetAllByCategoryId(string categoryId);
    }
}