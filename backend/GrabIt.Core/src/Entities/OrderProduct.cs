namespace GrabIt.Core.src.Entities
{
    public class OrderProduct : BaseEntity
    {
        public float Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}