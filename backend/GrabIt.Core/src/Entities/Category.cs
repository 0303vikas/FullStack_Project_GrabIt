namespace GrabIt.Core.src.Entities
{
    public class Category : BaseEntityWithDate
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}