
namespace GrabIt.Core.src.Entities
{
    public class Payment
    {
        public Order OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string Transection_id { get; set; }
    }
}