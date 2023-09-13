using Moq;
using AutoMapper;

using GrabIt.Service.ServiceInterfaces;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.Implementations;

namespace GrabIt.Test.src.Service
{
    public class OrderServiceTest
    {
        private readonly IOrderService _orderService;
        private readonly IOrderProductRepo _orderProductRepo;
        private readonly IProductRepo _productRepo;
        private readonly Mock<IOrderRepo> _orderRepoMock = new Mock<IOrderRepo>();
        private readonly Mock<IOrderProductRepo> _orderProductRepoMock = new Mock<IOrderProductRepo>();
        private readonly Mock<IProductRepo> _productRepoMock = new Mock<IProductRepo>();

        public OrderServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Order, OrderReadDto>();
               cfg.CreateMap<Order, OrderCreateDto>();
               cfg.CreateMap<OrderCreateDto, Order>();
               cfg.CreateMap<OrderUpdateDto, Order>();

               cfg.CreateMap<Product, ProductReadDto>();

               cfg.CreateMap<OrderProduct, OrderProductReadDto>();
               cfg.CreateMap<OrderProduct, OrderProductCreateDto>();
               cfg.CreateMap<OrderProductUpdateDto, OrderProduct>();
           });

            var mapper = config.CreateMapper();
            _orderService = new OrderService(_orderRepoMock.Object, _productRepoMock.Object, _orderProductRepoMock.Object, mapper);
        }

        [Fact]
        public void CreateOneOrder()
        {
            Guid orderId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            Guid addressId = Guid.NewGuid();

            Guid productId1 = Guid.NewGuid();
            Guid productId2 = Guid.NewGuid();

            var product1 = new Product()
            {
                Id = productId1,
                Title = "Product 1",
                Description = "Product 1 Description",
                Price = 100,
                Stock = 10,
                CategoryId = Guid.NewGuid()
            };

            var product2 = new Product()
            {
                Id = productId2,
                Title = "Product 2",
                Description = "Product 2 Description",
                Price = 200,
                Stock = 20,
                CategoryId = Guid.NewGuid()
            };

            var orderProduct1 = new OrderProductUpdateDto()
            {
                ProductId = productId1,
                Quantity = 5
            };

            var orderProduct2 = new OrderProductUpdateDto()
            {
                ProductId = productId2,
                Quantity = 10
            };

            var order = new Order()
            {
                Id = orderId,
                UserId = userId,
                AddressId = addressId,
                TotalPrice = 200 * 10 + 100 * 5,
                Status = OrderStatusType.InProcess
            };

            var orderCreateDto = new OrderCreateDto()
            {
                UserId = userId,
                AddressId = addressId,
                OrderProducts = new List<OrderProductUpdateDto>()
                {
                    orderProduct1,
                    orderProduct2
                }
            };

            var updatedProduct1 = new Product()
            {
                Id = productId1,
                Title = "Product 1",
                Description = "Product 1 Description",
                Price = 100,
                Stock = 5,
                CategoryId = Guid.NewGuid()
            };

            var updatedProduct2 = new Product()
            {
                Id = productId2,
                Title = "Product 2",
                Description = "Product 2 Description",
                Price = 200,
                Stock = 10,
                CategoryId = Guid.NewGuid()
            };

            _orderRepoMock.Setup(repo => repo.CreateOne(It.IsAny<Order>())).ReturnsAsync(order);
            _productRepoMock.Setup(repo => repo.GetOneById(productId1)).ReturnsAsync(product1);
            _productRepoMock.Setup(repo => repo.GetOneById(productId2)).ReturnsAsync(product2);
            _productRepoMock.Setup(repo => repo.UpdateOne(It.IsAny<Product>())).ReturnsAsync(updatedProduct1);
            _productRepoMock.Setup(repo => repo.UpdateOne(It.IsAny<Product>())).ReturnsAsync(updatedProduct2);


            var result = _orderService.CreateOne(orderCreateDto).Result;

            _productRepoMock.Verify(repo => repo.GetOneById(productId1), Times.Once);
            _productRepoMock.Verify(repo => repo.GetOneById(productId2), Times.Once);
            _productRepoMock.Verify(repo => repo.UpdateOne(It.IsAny<Product>()), Times.Exactly(2));


            _orderRepoMock.Verify(repo => repo.CreateOne(It.IsAny<Order>()), Times.Once);

            Assert.NotNull(result);
            Assert.IsType<OrderReadDto>(result);
            Assert.Equal(order.TotalPrice, result.TotalPrice);
            Assert.Equal(order.Status, result.Status);
        }

    }
}