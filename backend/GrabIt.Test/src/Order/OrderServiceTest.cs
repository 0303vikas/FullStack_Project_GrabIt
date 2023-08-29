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
        private readonly Mock<IOrderRepo> _orderRepoMock = new Mock<IOrderRepo>();

        public OrderServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Order, OrderReadDto>();
               cfg.CreateMap<Order, OrderCreateDto>();
               cfg.CreateMap<OrderCreateDto, Order>();
               cfg.CreateMap<OrderUpdateDto, Order>();
           });

            var mapper = config.CreateMapper();
            _orderService = new OrderService(_orderRepoMock.Object, mapper);
        }

        [Fact]
        public void CreateOneOrder()
        {
            Guid orderId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            Guid addressId = Guid.NewGuid();
            var order = new Order()
            {
                Id = orderId,
                UserId = userId,
                AddressId = addressId,
                TotalPrice = 100,
                Status = OrderStatusType.InProcess
            };

            var orderCreateDto = new OrderCreateDto()
            {
                UserId = userId,
                AddressId = addressId,
                TotalPrice = 100,
                Status = OrderStatusType.InProcess
            };

            _orderRepoMock.Setup(repo => repo.CreateOne(It.IsAny<Order>())).ReturnsAsync(order);

            var result = _orderService.CreateOne(orderCreateDto).Result;

            _orderRepoMock.Verify(repo => repo.CreateOne(It.IsAny<Order>()), Times.Once);

            Assert.NotNull(result);
            Assert.IsType<OrderReadDto>(result);
            Assert.Equal(order.TotalPrice, result.TotalPrice);
            Assert.Equal(order.Status, result.Status);
        }
    }
}