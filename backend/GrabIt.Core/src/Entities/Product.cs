
namespace GrabIt.Core.src.Entities
{
    public class Product : BaseEntityWithDate
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Image> ImageURLList { get; set; }
    }
}