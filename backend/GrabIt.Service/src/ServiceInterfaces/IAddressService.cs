using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IAddressService : IBaseService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>
    {
        Task<IEnumerable<Address>?> GetAddressByUserId(Guid userId);
    }
}