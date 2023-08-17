using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Payment> _payment;
        public PaymentRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _payment = _context.Payments;
        }

        public async Task<Payment?> GetOneByTransectionId(string id)
        {
            return await _payment.FirstOrDefaultAsync(p => p.TransectionId == id);
        }
    }
}