using GrabIt.Core.src.Entities;

// GetOne, GetAll,updateone, deleteOne, CreateOne
namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IPaymentRepo : IBaseRepo<Payment>
    {
        Task<Payment?> GetOneByTransectionId(string id);
    }
}