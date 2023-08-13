using GrabIt.Core.src.Entities;
using GrabIt.Service.src.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IAddressService : IBaseService<Address, AddressReadDto, AddressReadDto, AddressUpdateDto>
    {
    }
}