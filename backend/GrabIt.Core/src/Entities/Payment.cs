
namespace GrabIt.Core.src.Entities
{
    public class Payment : BaseEntity
    {
        public Order Order { get; set; }
        public string PaymentMethod { get; set; }
        public string Transection_id { get; set; }
    }
}