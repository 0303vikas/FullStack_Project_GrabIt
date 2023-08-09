using GrabIt.Core.src.Entities;

// GetOne, GetAll, Updateone, deleteOne, CreateOne
namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IProductRepo : IBaseWithCreateMethod<Product>
    {
        Task<IEnumerable<Product>> GetAllByCategoryId(Guid categoryId);
    }
}