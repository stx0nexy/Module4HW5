using Module4HW5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW5.Data.EntitiesConfigurations;

public class ShippersEntityConfigurations : IEntityTypeConfiguration<ShippersEntity>
{
    public void Configure(EntityTypeBuilder<ShippersEntity> builder)
    {
        builder.HasKey(h => h.ShipperID);
        builder.Property(p => p.CompanyName).IsRequired();
        builder.Property(p => p.Phone).IsRequired();
    }
    
}