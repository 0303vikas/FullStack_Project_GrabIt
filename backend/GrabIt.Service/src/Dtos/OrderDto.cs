using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class OrderDto
    {
        public float TotalPrice { get; set; }
        public List<OrderProduct> Products { get; set; }
        public Address DeliveryAddress { get; set; }
        public OrderStatusType Status { get; set; }
        public Payment Payment { get; set; }
    }
}