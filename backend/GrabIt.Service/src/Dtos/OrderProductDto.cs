using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class OrderProductDto
    {
        public float Quantity { get; set; }
        public Product Product { get; set; }
    }
}