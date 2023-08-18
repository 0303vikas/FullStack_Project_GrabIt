using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class OrderProductReadDto
    {
        public float Quantity { get; set; }
        public Guid OrderId { get; set; }

        public ProductReadDto Product { get; set; }
    }

    public class OrderProductCreateDto
    {
        public float Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }

    public class OrderProductUpdateDto
    {
        public float Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}