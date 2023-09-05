using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Address> _address;
        public AddressRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _address = _context.Addresses;

        }

        public async Task<IEnumerable<Address>?> GetAddressByUserId(Guid userId)
        {
            return await _address.AsNoTracking().Where(a => a.UserId == userId).ToListAsync();
        }
    }
}