using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IOrderProductService : IBaseService<OrderProduct, OrderProductReadDto, OrderProductCreateDto, OrderProductUpdateDto>
    {

    }
}