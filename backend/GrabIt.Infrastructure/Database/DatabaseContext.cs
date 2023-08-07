using GrabIt.Core.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users;
        public DbSet<Product> Products;
        public DbSet<Category> Categories;
        public DbSet<Payment> Payments;
        public DbSet<Image> Images;
        public DbSet<Order> Orders;
        public DbSet<OrderProduct> OrderProducts;
        public DbSet<Address> Addresses;
        public DbSet<Cart> Carts;
        public DbSet<CartProduct> CartProducts;


        public DatabaseContext()
        {

        }

    }
}