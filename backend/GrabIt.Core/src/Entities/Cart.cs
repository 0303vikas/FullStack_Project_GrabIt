namespace GrabIt.Core.src.Entities
{
    public class Cart : BaseEntity
    {
        public User User { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}