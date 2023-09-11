

namespace GrabIt.Core.src.Entities
{
    public class Order : BaseEntityWithDate
    {
        public float TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public OrderStatusType Status { get; set; }

        public Address Address { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
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