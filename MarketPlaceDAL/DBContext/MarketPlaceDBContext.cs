using MarketPlaceDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceDAL.DBContext
{
    public class MarketPlaceDBContext: IdentityDbContext<User, IdentityRole, string>
    {
        public MarketPlaceDBContext(DbContextOptions<MarketPlaceDBContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("identity");

            //OrderProduct
            builder.Entity<OrderProduct>()
                .Property(op => op.UnitPrice)
                .HasPrecision(18, 2);

            builder.Entity<OrderProduct>()
                .ToTable("OrderProducts", "mp")
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(o => o.OrderId);

            //Product
            builder.Entity<Product>()
                .Property(op => op.Price)
                .HasPrecision(18, 2);

            builder.Entity<Product>()
                .ToTable("Product", "mp")
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Product>()
                .HasOne(p => p.Shop)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.ShopId);

            //Order
            builder.Entity<Order>()
                .ToTable("Order", "mp")
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            //OrderStatusChange
            builder.Entity<OrderStatusChange>()
                .ToTable("OrderStatusChange", "mp")
                .HasOne(osc => osc.Order)
                .WithMany(o => o.OrderStatusChanges)
                .HasForeignKey(o => o.OrderId);

            //Category
            builder.Entity<Category>()
                .ToTable("Category", "mp");

            //ProductImage
            builder.Entity<ProductImage>()
                .ToTable("ProductImage", "mp")
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.ProductId);

            //Shop
            builder.Entity<Shop>()
                .ToTable("Shop", "mp")
                .HasOne(s => s.Owner)
                .WithMany(o => o.Shops)
                .HasForeignKey(s => s.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderStatusChange> OrderStatusChanges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}
