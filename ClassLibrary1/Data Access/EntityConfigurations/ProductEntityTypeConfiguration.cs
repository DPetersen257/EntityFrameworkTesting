using ClassLibrary1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary1.Data_Access.EntityConfigurations;

internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<IProduct>
{
    public void Configure(EntityTypeBuilder<IProduct> builder)
    {
        builder
            .HasKey(p => p.ProductID);

        builder
            .Property(p => p.Name)
            .IsRequired();
    }
}
