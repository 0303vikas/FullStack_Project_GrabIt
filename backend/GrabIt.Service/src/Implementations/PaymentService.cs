using AutoMapper;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo _paymentRepo;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepo paymentRepo, IMapper mapper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
        }

        public PaymentDto GetByOrderId(string id)
        {
            var foundPayment = _paymentRepo.GetByOrderId(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Payment with id: {id} was found.");
            return _mapper.Map<PaymentDto>(foundPayment);
        }
    }
}