namespace GrabIt.Core.src.Entities
{
    public class CartProduct : BaseEntity
    {
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}