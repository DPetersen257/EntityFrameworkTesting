using ClassLibrary1.Data_Access.EntityConfigurations;
using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Data_Access;

public class MyAppContext : DbContext
{
    public MyAppContext() { }

    public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase("DBMemory");
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        builder.ApplyConfiguration(new ProductEntityTypeConfiguration());
    }
}
