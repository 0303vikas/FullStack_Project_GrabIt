using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class PaymentRepository : IPaymentRepo
    {
        // public Payment GetByOrderId(string id)
        // {
        //     throw new NotImplementedException();
        // }
        public Task<Payment> CreateOne(Payment createData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetOneByTransectionId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> UpdateOne(Payment originalData, Payment updateData)
        {
            throw new NotImplementedException();
        }
    }
}