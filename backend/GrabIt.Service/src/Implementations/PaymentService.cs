using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class PaymentService : BaseService<Payment, PaymentDto>, IPaymentService
    {
        private readonly IPaymentRepo _paymentRepo;

        public PaymentService(IPaymentRepo paymentRepo, IMapper mapper) : base(paymentRepo, mapper)
        {
            _paymentRepo = paymentRepo;
        }

        public Task<OrderProductDto> CreateOne(OrderProductDto createData)
        {
            throw new NotImplementedException();
        }
    }
}