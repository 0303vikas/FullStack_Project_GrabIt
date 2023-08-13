using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Controller.src.Controllers
{
    public class PaymentController : GenericBaseController<Payment, PaymentReadDto, PaymentCreateDto, PaymentUpdateDto>
    {
        public PaymentController(IPaymentService baseRepo) : base(baseRepo)
        {
        }
    }
}