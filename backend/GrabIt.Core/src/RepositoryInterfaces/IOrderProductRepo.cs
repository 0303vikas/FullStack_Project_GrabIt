using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IOrderProductRepo : IBaseRepo<OrderProduct>
    {
        Task<float> GetProductStock(Guid productId);
    }
}