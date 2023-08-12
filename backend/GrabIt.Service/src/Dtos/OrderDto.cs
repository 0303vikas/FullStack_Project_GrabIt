using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class OrderReadDto
    {
        public float TotalPrice { get; set; }
        public List<OrderProduct> Products { get; set; }
        public Address DeliveryAddress { get; set; }
        public OrderStatusType Status { get; set; }
        public Payment Payment { get; set; }
    }

    public class OrderCreateDto
    {
        public float TotalPrice { get; set; }
        public List<OrderProduct> Products { get; set; }
        public Address DeliveryAddress { get; set; }
        public OrderStatusType Status { get; set; }
        public Payment Payment { get; set; }
    }

    public class OrderUpdateDto
    {
        public float TotalPrice { get; set; }
        public List<OrderProduct> Products { get; set; }
        public OrderStatusType Status { get; set; }
    }
}