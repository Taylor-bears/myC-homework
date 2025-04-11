using Microsoft.EntityFrameworkCore;

namespace 订单管理
{
    public class OrderContext : DbContext
    {
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetails>? OrderDetails { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Details)
                .WithOne()
                .HasForeignKey(d => d.OrderId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.OrderId, od.ProductName });
        }
    }
}