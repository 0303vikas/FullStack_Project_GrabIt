namespace GrabIt.Core.src.Entities
{
    public class Cart : BaseEntity
    {
        public User UserId { get; set; }
        public Dictionary<int, Product> CartProducts { get; set; }
    }
}