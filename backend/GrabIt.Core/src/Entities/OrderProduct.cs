namespace GrabIt.Core.src.Entities
{
    public class OrderProduct : BaseEntity
    {
        public float Quantity { get; set; }
        public Product Product { get; set; }
        public Order OrderId { get; set; }

    }
}