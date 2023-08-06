using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IPaymentRepo
    {
        Payment GetByOrderId(string id);

    }
}