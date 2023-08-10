using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class AddressService : BaseServiceWithoutDto<Address>, IAddressService
    {
        private readonly IAddressRepo _addressRepo;

        public AddressService(IAddressRepo addressRepo) : base(addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public async Task<Address> CreateOne(Address createData)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Address>> GetAllUserAddressByAddressId(IEnumerable<Guid> ids)
        {
            if (ids.Count() <= 0)
            {
                return new List<Address>();
            }
            return await _addressRepo.GetAllByUserId(ids);
        }
    }
}