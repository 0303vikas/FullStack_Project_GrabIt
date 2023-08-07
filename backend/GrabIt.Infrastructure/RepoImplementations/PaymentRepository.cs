using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class PaymentRepository : IPaymentRepo
    {
        public Payment GetByOrderId(string id)
        {
            throw new NotImplementedException();
        }
    }
}