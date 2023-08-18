using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace GrabIt.Controller.src.Controllers
{
    [Authorize]
    public class PaymentController : GenericBaseControllerWithoutGetMethods<Payment, PaymentReadDto, PaymentCreateDto, PaymentUpdateDto>
    {
        public PaymentController(IPaymentService baseRepo) : base(baseRepo)
        {
        }
    }
}