using Module4HW5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW5.Data.EntitiesConfigurations;

public class CategoryEntityConfigurations : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(h => h.CategoryID);
        builder.Property(p => p.CategoryName).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Picture).IsRequired();
        builder.Property(p => p.Active).IsRequired();
    }
    
}