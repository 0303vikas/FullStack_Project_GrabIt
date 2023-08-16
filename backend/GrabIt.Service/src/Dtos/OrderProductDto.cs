using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class OrderProductReadDto
    {
        public float Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }

    public class OrderProductCreateDto
    {
        public float Quantity { get; set; }
        public Product ProductId { get; set; }
        public Order OrderId { get; set; }
    }

    public class OrderProductUpdateDto
    {
        public float Quantity { get; set; }
        public Product ProductId { get; set; }
    }
}