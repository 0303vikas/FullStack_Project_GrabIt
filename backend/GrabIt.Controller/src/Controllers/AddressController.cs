using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace GrabIt.Controller.src.Controllers
{
    [Authorize]
    public class AddressController : GenericBaseControllerWithoutGetMethods<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>
    {
        public AddressController(IAddressService baseService) : base(baseService)
        {
        }
    }
}