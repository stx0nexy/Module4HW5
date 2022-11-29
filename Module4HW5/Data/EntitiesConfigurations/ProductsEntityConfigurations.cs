using Module4HW5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW5.Data.EntitiesConfigurations;

public class ProductsEntityConfigurations : IEntityTypeConfiguration<ProductsEntity>
{
    public void Configure(EntityTypeBuilder<ProductsEntity> builder)
    {
        builder.HasKey(h => h.ProductID);
        builder.Property(p => p.SKU).IsRequired();
        builder.Property(p => p.IDSKU).IsRequired();
        builder.Property(p => p.VendorProductID).IsRequired();
        builder.Property(p => p.ProductName).IsRequired();
        builder.Property(p => p.ProductDescription).IsRequired();
        builder.Property(p => p.QuantityPerUnit).IsRequired();
        builder.Property(p => p.UnitPrice).IsRequired();
        builder.Property(p => p.MSRP).IsRequired();
        builder.Property(p => p.AvailableSize).IsRequired();
        builder.Property(p => p.AvailableColors).IsRequired();
        builder.Property(p => p.Size).IsRequired();
        builder.Property(p => p.Color).IsRequired();
        builder.Property(p => p.Discount).IsRequired();
        builder.Property(p => p.UnitWeight).IsRequired();
        builder.Property(p => p.UnitsInStock).IsRequired();
        builder.Property(p => p.UnitsOnOrder).IsRequired();
        builder.Property(p => p.ReorderLevel).IsRequired();
        builder.Property(p => p.ProductAvailable).IsRequired();
        builder.Property(p => p.DiscountAvailable).IsRequired();
        builder.Property(p => p.CurrentOrder).IsRequired();
        builder.Property(p => p.Picture).IsRequired();
        builder.Property(p => p.Ranking).IsRequired();
        builder.Property(p => p.Note).IsRequired();
        
        builder.HasOne(h => h.CategoryEntity)
            .WithMany(w => w.ProductsEntities)
            .HasForeignKey(h => h.CategoryID)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(h => h.SuppliersEntity)
            .WithMany(w => w.ProductsEntities)
            .HasForeignKey(h => h.SupplierID)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}