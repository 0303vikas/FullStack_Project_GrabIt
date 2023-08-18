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
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Cart>().HasKey("UserId");
            modelBuilder.Entity<Payment>().HasIndex(p => p.TransectionId).IsUnique();
            modelBuilder.Entity<Payment>().HasKey("OrderId");

            // auto navigation properties
            modelBuilder.Entity<Product>().Navigation(e => e.Category).AutoInclude();
            modelBuilder.Entity<OrderProduct>().Navigation(e => e.Product).AutoInclude();
            modelBuilder.Entity<CartProduct>().Navigation(e => e.Product).AutoInclude();
            modelBuilder.Entity<Cart>().Navigation(e => e.CartProducts).AutoInclude();

            // Foreign Keys
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        }
    }
}