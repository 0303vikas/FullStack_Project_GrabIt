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
        private readonly IProductRepo _productRepo;
        private readonly IOrderProductRepo _orderProductRepo;
        public OrderService(IOrderRepo orderRepo, IProductRepo productRepo, IOrderProductRepo orderProductRepo, IMapper mapper) : base(orderRepo, mapper)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _orderProductRepo = orderProductRepo;
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
            if (
                createData.UserId.Equals(Guid.Empty) ||
                createData.AddressId.Equals(Guid.Empty)
                ) throw ErrorHandlerService.ExceptionArgumentNull("User and Address can't be null.");

            float totalPrice = 0;

            //check product
            foreach (var orderProduct in createData.OrderProducts)
            {
                if (orderProduct.ProductId.Equals(Guid.Empty)) throw ErrorHandlerService.ExceptionArgumentNull("Product can't be null.");
                var product = await _productRepo.GetOneById(orderProduct.ProductId);
                if (product == null) throw ErrorHandlerService.ExceptionNotFound($"Product with id: {orderProduct.ProductId} not found.");
                if (orderProduct.Quantity > product.Stock) throw ErrorHandlerService.ExceptionArgumentNull($"Product with id: {orderProduct.ProductId} not enough.");
                totalPrice += orderProduct.Quantity * product.Price;
                product.Stock -= (int)orderProduct.Quantity;
                await _productRepo.UpdateOne(product);
            }

            //create order                      
            var mappedOrder = _mapper.Map<Order>(createData);
            mappedOrder.TotalPrice = totalPrice;
            mappedOrder.Status = OrderStatusType.InProcess;

            var createdEntity = await _orderRepo.CreateOne(mappedOrder) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error creating item.");

            return _mapper.Map<OrderReadDto>(createdEntity);
        }

        // delete One

        public override async Task<bool> DeleteOneById(Guid id)
        {
            var foundOrder = await _orderRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            foreach (var orderProduct in foundOrder.OrderProducts)
            {
                var findProduct = await _productRepo.GetOneById(orderProduct.ProductId) ?? throw ErrorHandlerService.ExceptionNotFound($"No Product with id: {id} was found.");
                findProduct.Stock += (int)orderProduct.Quantity;
                await _productRepo.UpdateOne(findProduct);
                await _orderProductRepo.DeleteOneById(orderProduct.Id);
            }
            await _orderRepo.DeleteOneById(id);
            return true;
        }
    }
}