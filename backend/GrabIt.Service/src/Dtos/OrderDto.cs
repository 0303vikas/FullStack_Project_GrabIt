using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class OrderReadDto
    {
        public Guid Id { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatusType Status { get; set; }

        public AddressReadDto Address { get; set; }
        public List<OrderProductReadDto> OrderProducts { get; set; }

    }

    public class OrderCreateDto
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public List<OrderProductUpdateDto> OrderProducts { get; set; }
    }

    public class OrderUpdateDto
    {
        public float TotalPrice { get; set; }
        public Guid AddressId { get; set; }
        public OrderStatusType Status { get; set; }
    }
}