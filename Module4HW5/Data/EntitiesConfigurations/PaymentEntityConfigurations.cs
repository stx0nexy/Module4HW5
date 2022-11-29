using Module4HW5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW5.Data.EntitiesConfigurations;

public class PaymentEntityConfigurations : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        builder.HasKey(h => h.PaymentID);
        builder.Property(p => p.PaymentType).IsRequired();
        builder.Property(p => p.Allowed).IsRequired();
    }
    
}