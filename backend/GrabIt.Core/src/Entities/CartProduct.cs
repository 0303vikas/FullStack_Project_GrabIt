namespace GrabIt.Core.src.Entities
{
    public class CartProduct : BaseEntity
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}