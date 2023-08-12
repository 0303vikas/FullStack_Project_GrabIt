using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class CartReadDto
    {
        public Dictionary<int, Product> CartProducts { get; set; }
    }

    public class CartCreateDto
    {
        public Dictionary<int, Product> CartProducts { get; set; }
    }

    public class CartUpdateDto
    {
        public Dictionary<int, Product> CartProducts { get; set; }
    }
}