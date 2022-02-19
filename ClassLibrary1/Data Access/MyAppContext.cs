using ClassLibrary1.Data_Access.EntityConfigurations;
using ClassLibrary1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Data_Access;

public class MyAppContext : DbContext
{
    public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
    {
    }

    public DbSet<ICategory> Categories => Set<ICategory>();
    public DbSet<IProduct> Products => Set<IProduct>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        builder.ApplyConfiguration(new ProductEntityTypeConfiguration());
    }
}
