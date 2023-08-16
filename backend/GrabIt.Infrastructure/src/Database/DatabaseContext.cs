using GrabIt.Core.src.Entities;
using GrabIt.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GrabIt.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        static DatabaseContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var context = new NpgsqlDataSourceBuilder(_configuration.GetConnectionString("DefaultConnection"));
            context.MapEnum<UserRole>();
            context.MapEnum<OrderStatusType>();
            optionsBuilder.AddInterceptors(new TimeStampInterceptor());
            optionsBuilder.UseNpgsql(context.Build()).UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<UserRole>();
            modelBuilder.HasPostgresEnum<OrderStatusType>();
            modelBuilder.Entity<OrderProduct>().HasKey("OrderId", "ProductId");
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }
}