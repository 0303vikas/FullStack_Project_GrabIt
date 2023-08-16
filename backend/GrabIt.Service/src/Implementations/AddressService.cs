using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class AddressService : BaseService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>, IAddressService
    {
        private readonly IAddressRepo _addressRepo;

        public AddressService(IAddressRepo addressRepo, IMapper mapper) : base(addressRepo, mapper)
        {
            _addressRepo = addressRepo;
        }
    }
}