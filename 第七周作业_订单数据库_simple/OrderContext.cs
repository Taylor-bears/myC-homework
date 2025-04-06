using Microsoft.EntityFrameworkCore;

namespace 订单管理
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "server=localhost;database=orderdb;user=root;password=Syh200412",
                    new MySqlServerVersion(new Version(8, 0, 25)),
                    options => options.EnableRetryOnFailure()
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置Order和OrderDetails的关系
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Details)
                .WithOne()
                .HasForeignKey(d => d.OrderId);
         
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId); // 设置OrderId为主键
           
            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.OrderId, od.ProductName }); // 这里设置OrderDetails的主键
        }
    }
}