using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IPaymentService
    {
        Task<PaymentDto> GetByOrderId(string id);
    }
}