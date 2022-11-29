using Microsoft.EntityFrameworkCore;
using Module4HW5.Data.Entities;
using Module4HW5.Data.EntitiesConfigurations;

namespace Module4HW5.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CustomersEntity> Customers { get; set; }
    public DbSet<OrderDetailsEntity> OrderDetails { get; set; }
    public DbSet<OrdersEntity> Orders { get; set; }
    public DbSet<PaymentEntity> Payments { get; set; }
    public DbSet<ProductsEntity> Products { get; set; }
    public DbSet<ShippersEntity> Shippers { get; set; }
    public DbSet<SuppliersEntity> Suppliers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryEntityConfigurations());
        modelBuilder.ApplyConfiguration(new CustomersEntityConfigurations());
        modelBuilder.ApplyConfiguration(new OrderDetailsEntityConfigurations());
        modelBuilder.ApplyConfiguration(new OrdersEntityConfigurations());
        modelBuilder.ApplyConfiguration(new PaymentEntityConfigurations());
        modelBuilder.ApplyConfiguration(new ProductsEntityConfigurations());
        modelBuilder.ApplyConfiguration(new ShippersEntityConfigurations());
        modelBuilder.ApplyConfiguration(new SuppliersEntityConfiguration());
        modelBuilder.UseHiLo();
    }
    
}