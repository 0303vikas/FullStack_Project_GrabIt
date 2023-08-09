using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IPaymentRepo
    {
        Task<Payment> GetByOrderId(string id);

    }
}