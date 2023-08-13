using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class OrderService : BaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>, IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo, IMapper mapper) : base(orderRepo, mapper)
        {
            _orderRepo = orderRepo;
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByUserId(Guid userId)
        {
            return _mapper.Map<IEnumerable<OrderReadDto>>(await _orderRepo.GetOrdersByUserId(userId));
        }

        public async Task<OrderReadDto> UpdateOrderStatus(Guid orderId, OrderStatusType orderStatus)
        {
            return _mapper.Map<OrderReadDto>(await _orderRepo.UpdateOrderStatus(orderId, orderStatus));
        }

        public override async Task<OrderReadDto> CreateOne(OrderCreateDto createData)
        {
            //price error 
            if (createData.Payment == null || createData.Products == null || createData.DeliveryAddress == null) throw ErrorHandlerService.ExceptionArgumentNull("Payment, Products and DeliveryAddress can't be null.");
            if (createData.TotalPrice <= 0) throw ErrorHandlerService.ExceptionArgumentNull("TotalPrice can't be less than or equal to 0.");
            if (createData.Products.Count() <= 0) throw ErrorHandlerService.ExceptionArgumentNull("Products can't be empty.");

            return await base.CreateOne(createData);
        }

        // Update One



    }

}