using Moq;
using AutoMapper;

using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.Implementations;
using GrabIt.Service.ServiceInterfaces;
using GrabIt.Core.src.Entities;

namespace GrabIt.Test.src.Service
{
    public class ProductServiceTest
    {
        private readonly IProductService _productService;
        private readonly Mock<IProductRepo> _productRepoMock = new Mock<IProductRepo>();

        public ProductServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Product, ProductReadDto>();
               cfg.CreateMap<Product, ProductCreateDto>();
               cfg.CreateMap<ProductCreateDto, Product>();
               cfg.CreateMap<ProductUpdateDto, Product>();
           });
            var mapper = config.CreateMapper();
            _productService = new ProductService(_productRepoMock.Object, mapper);
        }

        [Fact]
        public void GetAllByCategoryId_return_ListofProducts_UnderACategory()
        {
            //Arrange
            var categoryId = Guid.NewGuid();
            var categoryId2 = Guid.NewGuid();
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Title = "Product 1",
                    Description = "Product 1 Description",
                    Price = 100,
                    Stock = 10,
                    CategoryId = categoryId
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Title = "Product 2",
                    Description = "Product 2 Description",
                    Price = 200,
                    Stock = 20,
                    CategoryId = categoryId
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Title = "Product 3",
                    Description = "Product 3 Description",
                    Price = 300,
                    Stock = 30,
                    CategoryId = categoryId2
                }
            };
            _productRepoMock.Setup(repo => repo.GetAllByCategoryId(categoryId)).ReturnsAsync(products.Where(e => e.CategoryId == categoryId));

            var result = _productService.GetAllByCategoryId(categoryId).Result;

            //Assert
            Assert.Equal(products.FindAll(e => e.CategoryId == categoryId).Count(), result.Count());
        }

        [Fact]
        public async Task CreateOneProduct()
        {
            Guid productId = Guid.NewGuid();
            Product product = new Product()
            {
                Id = productId,
                Title = "Product 1",
                Description = "Product 1 Description",
                Price = 100,
                Stock = 10,
                CategoryId = Guid.NewGuid(),
                ImageURLList = new List<string>(),
            };

            ProductCreateDto productCreate = new ProductCreateDto()
            {
                Title = "Product 1",
                Description = "Product 1 Description",
                Price = 100,
                Stock = 10,
                CategoryId = Guid.NewGuid(),
                ImageURLList = new List<string>(),
            };

            _productRepoMock.Setup(repo => repo.CreateOne(It.IsAny<Product>())).ReturnsAsync(product);

            var result = await _productService.CreateOne(productCreate);

            _productRepoMock.Verify(repo => repo.CreateOne(It.IsAny<Product>()), Times.Once);

            Assert.NotNull(result);
            Assert.IsType<ProductReadDto>(result);
            Assert.Equal(product.Title, result.Title);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.Price, result.Price);
            Assert.Equal(product.Id, result.Id);
            Assert.Equal(product.ImageURLList, result.ImageURLList);

        }

        [Fact]
        public async Task ProductUpdate_Returns_Updated_Product()
        {

            Guid productId = Guid.NewGuid();
            Product product = new Product()
            {
                Id = productId,
                Title = "Product 1",
                Description = "Product 1 Description",
                Price = 100,
                Stock = 10,
                CategoryId = Guid.NewGuid(),
                ImageURLList = new List<string>(),
            };

            Guid newCategoryId = Guid.NewGuid();
            var UpdatedProduct = new Product()
            {
                Id = productId,
                Title = "Product 1 Updated",
                Description = "Product 1 Description Updated",
                Price = 100,
                Stock = 18,
                CategoryId = newCategoryId,
                ImageURLList = new List<string>(),
            };


            ProductUpdateDto UpdatedProductDto = new ProductUpdateDto()
            {
                Title = "Product 1 Updated",
                Description = "Product 1 Description Updated",
                Price = 100,
                Stock = 18,
                CategoryId = newCategoryId,
                ImageURLList = new List<string>(),
            };

            _productRepoMock.Setup(repo => repo.GetOneById(productId)).ReturnsAsync(product);
            _productRepoMock.Setup(repo => repo.UpdateOne(It.IsAny<Product>())).ReturnsAsync(product);

            var result = await _productService.UpdateOneById(productId, UpdatedProductDto);

            _productRepoMock.Verify(repo => repo.UpdateOne(It.IsAny<Product>()), Times.Once);
            _productRepoMock.Verify(repo => repo.GetOneById(productId), Times.Once);

            Assert.NotNull(result);
            Assert.IsType<ProductReadDto>(result);
            Assert.Equal(UpdatedProduct.Title, result.Title);
            Assert.Equal(UpdatedProduct.Description, result.Description);
            Assert.Equal(UpdatedProduct.Price, result.Price);
            Assert.Equal(UpdatedProduct.Id, result.Id);
            Assert.Equal(UpdatedProduct.ImageURLList, result.ImageURLList);
        }
    }
}