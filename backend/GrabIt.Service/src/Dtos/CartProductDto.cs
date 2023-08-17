using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class CartProductReadDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }

    public class CartProductCreateDto
    {
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
    }

    public class CartProductUpdateDto
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}