

using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class ProductDto
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Image> ImageURLList { get; set; }

    }
}