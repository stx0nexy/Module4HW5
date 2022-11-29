using Module4HW5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW5.Data.EntitiesConfigurations;

public class OrdersEntityConfigurations : IEntityTypeConfiguration<OrdersEntity>
{
    public void Configure(EntityTypeBuilder<OrdersEntity> builder)
    {
        builder.HasKey(h => h.OrderID);
        builder.Property(p => p.OrderNumber).IsRequired();
        builder.Property(p => p.OrderDate).IsRequired();
        builder.Property(p => p.ShipDate).IsRequired();
        builder.Property(p => p.RequiredDate).IsRequired();
        builder.Property(p => p.Freight).IsRequired();
        builder.Property(p => p.SalesTax).IsRequired();
        builder.Property(p => p.Timestamp).IsRequired();
        builder.Property(p => p.TransactStatus).IsRequired();
        builder.Property(p => p.ErrLoc).IsRequired();
        builder.Property(p => p.ErrMsg).IsRequired();
        builder.Property(p => p.Fulfilled).IsRequired();
        builder.Property(p => p.Deleted).IsRequired();
        builder.Property(p => p.Paid).IsRequired();
        builder.Property(p => p.PaymentDate).IsRequired();
        
        builder.HasOne(h => h.CustomersEntity)
            .WithMany(w => w.OrdersEntities)
            .HasForeignKey(h => h.CustomerID)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(h => h.PaymentEntity)
            .WithMany(w => w.OrdersEntities)
            .HasForeignKey(h => h.PaymentID)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(h => h.ShippersEntity)
            .WithMany(w => w.OrdersEntities)
            .HasForeignKey(h => h.ShipperID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}