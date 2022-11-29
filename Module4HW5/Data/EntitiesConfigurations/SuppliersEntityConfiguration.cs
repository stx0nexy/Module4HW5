using Module4HW5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW5.Data.EntitiesConfigurations;

public class SuppliersEntityConfiguration : IEntityTypeConfiguration<SuppliersEntity>
{
    public void Configure(EntityTypeBuilder<SuppliersEntity> builder)
    {
        builder.HasKey(h => h.SupplierID);
        builder.Property(p => p.CompanyName).IsRequired();
        builder.Property(p => p.ContactFName).IsRequired();
        builder.Property(p => p.ContactLName).IsRequired();
        builder.Property(p => p.ContactTitle).IsRequired();
        builder.Property(p => p.Address1).IsRequired();
        builder.Property(p => p.Address2).IsRequired();
        builder.Property(p => p.City).IsRequired();
        builder.Property(p => p.State).IsRequired();
        builder.Property(p => p.PostalCode).IsRequired();
        builder.Property(p => p.Country).IsRequired();
        builder.Property(p => p.Phone).IsRequired();
        builder.Property(p => p.Fax).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.URL).IsRequired();
        builder.Property(p => p.PaymentMethods).IsRequired();
        builder.Property(p => p.DiscountType).IsRequired();
        builder.Property(p => p.TypeGoods).IsRequired();
        builder.Property(p => p.Notes).IsRequired();
        builder.Property(p => p.DiscountAvailable).IsRequired();
        builder.Property(p => p.CurrentOrder).IsRequired();
        builder.Property(p => p.Logo).IsRequired();
        builder.Property(p => p.SizeURL).IsRequired();
        builder.Property(p => p.CustomerID).IsRequired();
        builder.Property(p => p.SupplierID).IsRequired();
    }
}