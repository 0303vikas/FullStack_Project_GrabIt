using GrabIt.Core.src.Entities;

namespace GrabIt.Service.src.Dtos
{
    public class CartProductReadDto
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }

    public class CartProductCreateDto
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }

    public class CartProductUpdateDto
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}