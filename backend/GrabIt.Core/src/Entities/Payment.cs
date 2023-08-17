
namespace GrabIt.Core.src.Entities
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string TransectionId { get; set; }
    }
}