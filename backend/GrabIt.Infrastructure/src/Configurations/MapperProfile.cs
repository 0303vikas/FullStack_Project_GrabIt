using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Infrastructure.src.Configurations
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<User, UserCreateDto>();
            CreateMap<UserReadDto, User>();

            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();
            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductReadDto, Product>();

            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<CategoryReadDto, Category>();

            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<Order, OrderUpdateDto>();
            CreateMap<Order, OrderCreateDto>();
            CreateMap<OrderReadDto, Order>();

            CreateMap<Image, ImageReadDto>();
            CreateMap<ImageCreateDto, Image>();
            CreateMap<ImageUpdateDto, Image>();
            CreateMap<Image, ImageUpdateDto>();
            CreateMap<Image, ImageCreateDto>();
            CreateMap<ImageReadDto, Image>();

            CreateMap<Cart, CartReadDto>();
            CreateMap<CartCreateDto, Cart>();
            CreateMap<CartUpdateDto, Cart>();
            CreateMap<Cart, CartUpdateDto>();
            CreateMap<Cart, CartCreateDto>();
            CreateMap<CartReadDto, Cart>();

            CreateMap<Address, AddressReadDto>();
            CreateMap<AddressCreateDto, Address>();
            CreateMap<AddressUpdateDto, Address>();
            CreateMap<Address, AddressUpdateDto>();
            CreateMap<Address, AddressCreateDto>();
            CreateMap<AddressReadDto, Address>();

            CreateMap<CartProduct, CartProductReadDto>();
            CreateMap<CartProductCreateDto, CartProduct>();
            CreateMap<CartProductUpdateDto, CartProduct>();
            CreateMap<CartProduct, CartProductUpdateDto>();
            CreateMap<CartProduct, CartProductCreateDto>();
            CreateMap<CartProductReadDto, CartProduct>();

            CreateMap<OrderProduct, OrderProductReadDto>();
            CreateMap<OrderProductCreateDto, OrderProduct>();
            CreateMap<OrderProductUpdateDto, OrderProduct>();
            CreateMap<OrderProduct, OrderProductUpdateDto>();
            CreateMap<OrderProduct, OrderProductCreateDto>();
            CreateMap<OrderProductReadDto, OrderProduct>();

            CreateMap<Payment, PaymentReadDto>();
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>();
            CreateMap<Payment, PaymentUpdateDto>();
            CreateMap<Payment, PaymentCreateDto>();
            CreateMap<PaymentReadDto, Payment>();

        }

    }
}