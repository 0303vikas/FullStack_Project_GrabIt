

namespace GrabIt.Core.src.Entities
{
    public class Order : BaseEntityWithDate
    {
        public float TotalPrice { get; set; }
        public List<OrderProduct> Products { get; set; }
        public User UserId { get; set; }
        public Address DeliveryAddress { get; set; }
    }
}