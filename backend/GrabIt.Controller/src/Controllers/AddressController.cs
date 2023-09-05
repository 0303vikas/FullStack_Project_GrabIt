using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    [Authorize]
    public class AddressController : GenericBaseControllerWithoutGetMethods<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService baseService) : base(baseService)
        {
            _addressService = baseService;
        }

        [Authorize]
        [HttpGet("/api/v1/users/{userId:Guid}/addresses")]
        public async Task<ActionResult<IEnumerable<Address>?>> GetAddressByUserId([FromRoute] Guid userId)
        {
            return Ok(await _addressService.GetAddressByUserId(userId));
        }
    }
}