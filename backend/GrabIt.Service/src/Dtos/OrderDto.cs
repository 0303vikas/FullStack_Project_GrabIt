using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class OrderReadDto
    {
        public float TotalPrice { get; set; }
        public OrderStatusType Status { get; set; }

        public Address Address { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public Payment Payment { get; set; }

    }

    public class OrderCreateDto
    {
        public float TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public OrderStatusType Status { get; set; }
    }

    public class OrderUpdateDto
    {
        public float TotalPrice { get; set; }
        public Guid AddressId { get; set; }
        public OrderStatusType Status { get; set; }
    }
}