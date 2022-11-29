using Module4HW5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW5.Data.EntitiesConfigurations;

public class OrderDetailsEntityConfigurations : IEntityTypeConfiguration<OrderDetailsEntity>
{
    public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
    {
        builder.HasKey(h => h.OrderDetailID);
        builder.Property(p => p.OrderNumber).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.Quantity).IsRequired();
        builder.Property(p => p.Discount).IsRequired();
        builder.Property(p => p.Total).IsRequired();
        builder.Property(p => p.IDSKU).IsRequired();
        builder.Property(p => p.Size).IsRequired();
        builder.Property(p => p.Color).IsRequired();
        builder.Property(p => p.Fulfilled).IsRequired();
        builder.Property(p => p.ShipDate).IsRequired();
        builder.Property(p => p.BillDate).IsRequired();
        
        builder.HasOne(h => h.OrdersEntity)
            .WithMany(w => w.OrderDetailsEntities)
            .HasForeignKey(h => h.OrderID)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(h => h.ProductsEntity)
            .WithMany(w => w.OrderDetailsEntities)
            .HasForeignKey(h => h.ProductID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}