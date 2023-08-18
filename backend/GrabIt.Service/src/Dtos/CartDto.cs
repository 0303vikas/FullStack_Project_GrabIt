using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class CartReadDto
    {
        public Guid UserId { get; set; }

        public List<CartProductReadDto> CartProducts { get; set; }
    }

    public class CartCreateDto
    {
        public Guid UserId { get; set; }
    }

    public class CartUpdateDto
    {
        public Guid UserId { get; set; }
    }
}