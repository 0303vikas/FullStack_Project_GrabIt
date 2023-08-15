using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class OrderProductService : BaseService<OrderProduct, OrderProductReadDto, OrderProductCreateDto, OrderProductUpdateDto>, IOrderProductService
    {
        private readonly IOrderProductRepo _orderProductRepo;

        public OrderProductService(IOrderProductRepo orderProductRepo, IMapper mapper) : base(orderProductRepo, mapper)
        {
            _orderProductRepo = orderProductRepo;
        }

        public override async Task<OrderProductReadDto> CreateOne(OrderProductCreateDto createData)
        {
            //Error Handling 
            if (createData.Product == null) throw ErrorHandlerService.ExceptionArgumentNull("OrderId and Product can't be empty or null.");
            if (createData.Quantity <= 0) throw ErrorHandlerService.ExceptionArgumentNull("Quantity can't be less than or equal to 0.");
            //Check Product Stock
            if (createData.Product.Stock < createData.Quantity) throw ErrorHandlerService.ExceptionBadRequest("Product Stock is less than Quantity.");

            var createdEntity = await base.CreateOne(createData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error occured while creating new OrderProduct.");
            return createdEntity;
        }

        public override async Task<OrderProductReadDto> UpdateOneById(Guid id, OrderProductUpdateDto updateData)
        {
            //Error Handling
            if (updateData.Quantity <= 0) throw ErrorHandlerService.ExceptionArgumentNull("Quantity can't be less than or equal to 0.");
            //Check Product Stock
            if (updateData.Product.Stock < updateData.Quantity) throw ErrorHandlerService.ExceptionBadRequest("Product Stock is less than Quantity.");

            var createdEntity = await base.UpdateOneById(id, updateData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error occured while updating OrderProduct.");
            return createdEntity;
        }
    }
}