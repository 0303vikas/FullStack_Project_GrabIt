using GrabIt.Core.src.Entities;

// GetOne, GetAll,updateone, deleteOne, CreateOne
namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IPaymentRepo
    {
        Task<Payment> GetOneByOrderId(Guid id);
        Task<IEnumerable<Payment>> GetAll();
        Task<Payment> UpdateOneByOrderId(Guid id, Payment payment);
        Task<bool> DeleteOneByOrderId(Guid id);
        Task<Payment> CreateOne(Payment payment);
    }
}