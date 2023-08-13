using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class PaymentService : BaseService<Payment, PaymentReadDto, PaymentCreateDto, PaymentUpdateDto>, IPaymentService
    {
        private readonly IPaymentRepo _paymentRepo;

        public PaymentService(IPaymentRepo paymentRepo, IMapper mapper) : base(paymentRepo, mapper)
        {
            _paymentRepo = paymentRepo;
        }

        public override async Task<PaymentReadDto> CreateOne(PaymentCreateDto createData)
        {
            //Error handling
            if (createData.PaymentMethod == null || createData.Transection_id == null) throw ErrorHandlerService.ExceptionArgumentNull("PaymentMethod and Transection Id can't be null.");
            if (createData.PaymentMethod == "" || createData.Transection_id == "") throw ErrorHandlerService.ExceptionArgumentNull("PaymentMethod and Transection Id can't be empty.");

            var createdEntity = await base.CreateOne(createData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error creating Payment.");
            return createdEntity;
        }

        public override async Task<PaymentReadDto> UpdateOneById(Guid id, PaymentUpdateDto updateData)
        {
            if (updateData.PaymentMethod == null || updateData.Transection_id == null) throw ErrorHandlerService.ExceptionArgumentNull("PaymentMethod and Transection Id can't be null.");
            if (updateData.PaymentMethod == "" || updateData.Transection_id == "") throw ErrorHandlerService.ExceptionArgumentNull("PaymentMethod and Transection Id can't be empty.");
            var createdEntity = await base.UpdateOneById(id, updateData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error Updating Payment.");
            return createdEntity;
        }
    }
}