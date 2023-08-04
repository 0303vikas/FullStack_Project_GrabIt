

namespace GrabIt.Core.src.Entities
{
    public class Cart : BaseEntity
    {
        public User UserId { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}