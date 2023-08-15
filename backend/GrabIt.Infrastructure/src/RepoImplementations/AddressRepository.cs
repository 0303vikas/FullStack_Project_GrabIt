using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Address> _addresses;
        public AddressRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _addresses = context.Addresses;
        }

        public Task<bool> UpdateUserAddress(Guid addressId)
        {
            throw new NotImplementedException();
        }
    }
}