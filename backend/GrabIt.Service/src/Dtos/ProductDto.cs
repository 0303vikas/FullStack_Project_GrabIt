using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class ProductReadDto
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Image> ImageURLList { get; set; }

    }

    public class ProductCreateDto
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }
        public List<Image> ImageURLList { get; set; }
    }

    public class ProductUpdateDto
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }
        public List<Image> ImageURLList { get; set; }
    }
}