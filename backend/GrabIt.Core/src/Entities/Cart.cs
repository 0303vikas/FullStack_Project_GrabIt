namespace GrabIt.Core.src.Entities
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }

        public List<CartProduct> CartProducts { get; set; }
    }
}