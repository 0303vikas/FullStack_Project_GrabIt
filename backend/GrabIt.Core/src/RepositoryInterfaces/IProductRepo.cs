using GrabIt.Core.src.Entities;

// GetOne, GetAll, Updateone, deleteOne, CreateOne
namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IProductRepo : IBaseRepo<Product>
    {
        Task<IEnumerable<Product>> GetAllByCategoryId(Guid categoryId);
    }
}