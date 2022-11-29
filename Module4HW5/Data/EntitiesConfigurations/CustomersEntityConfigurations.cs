using Module4HW5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW5.Data.EntitiesConfigurations;

public class CustomersEntityConfigurations : IEntityTypeConfiguration<CustomersEntity>
{
    public void Configure(EntityTypeBuilder<CustomersEntity> builder)
    {
        builder.HasKey(h => h.CustomerID);
        builder.Property(p => p.FirstName).IsRequired();
        builder.Property(p => p.LastName).IsRequired();
        builder.Property(p => p.Class).IsRequired();
        builder.Property(p => p.Room).IsRequired();
        builder.Property(p => p.Building).IsRequired();
        builder.Property(p => p.Address1).IsRequired();
        builder.Property(p => p.Address2).IsRequired();
        builder.Property(p => p.City).IsRequired();
        builder.Property(p => p.State).IsRequired();
        builder.Property(p => p.PostalCode).IsRequired();
        builder.Property(p => p.Country).IsRequired();
        builder.Property(p => p.Phone).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.VoiceMail).IsRequired();
        builder.Property(p => p.Password).IsRequired();
        builder.Property(p => p.CreditCard).IsRequired();
        builder.Property(p => p.CreditCardTypeID).IsRequired();
        builder.Property(p => p.CardExpMo).IsRequired();
        builder.Property(p => p.CardExpYr).IsRequired();
        builder.Property(p => p.BillingAddress).IsRequired();
        builder.Property(p => p.BillingCity).IsRequired();
        builder.Property(p => p.BillingRegion).IsRequired();
        builder.Property(p => p.BillingPostalCode).IsRequired();
        builder.Property(p => p.BillingCountry).IsRequired();
        builder.Property(p => p.ShipAddress).IsRequired();
        builder.Property(p => p.ShipCity).IsRequired();
        builder.Property(p => p.ShipRegion).IsRequired();
        builder.Property(p => p.ShipPostalCode).IsRequired();
        builder.Property(p => p.ShipCountry).IsRequired();
        builder.Property(p => p.DateEntered).IsRequired();
    }
    
}