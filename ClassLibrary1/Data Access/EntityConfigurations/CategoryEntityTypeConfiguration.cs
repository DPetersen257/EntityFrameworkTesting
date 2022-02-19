using ClassLibrary1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary1.Data_Access.EntityConfigurations;

internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<ICategory>
{
    public void Configure(EntityTypeBuilder<ICategory> builder)
    {
        builder
            .HasKey(p => p.CategoryID);

        builder
            .Property(p => p.Name)
            .IsRequired();
    }
}
