using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IPaymentService
    {
        PaymentDto GetByOrderId(string id);
    }
}