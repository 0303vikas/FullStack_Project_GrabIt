

namespace GrabIt.Core.src.Entities
{
    public class Order : BaseEntityWithDate
    {
        public float TotalPrice { get; set; }
        public List<OrderProduct> Products { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
        public OrderStatusType Status { get; set; }
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