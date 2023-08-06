

namespace GrabIt.Core.src.Entities
{
    public class Order : BaseEntityWithDate
    {
        public float TotalPrice { get; set; }
        public List<OrderProduct> Products { get; set; }
        public User UserId { get; set; }
        public Address DeliveryAddress { get; set; }
        public OrderStatusType Status { get; set; }
        public Payment Payment { get; set; }
    }

    public enum OrderStatusType
    {
        Delivered,
        Shipped,
        InProcess,
        Waiting,
        Canceled
    }
}