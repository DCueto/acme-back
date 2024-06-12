using Microsoft.EntityFrameworkCore;

namespace acme_back.Data;

public class AppDbContext(DbContextOptions options) : DbContext( options )
{
    public DbSet<Product.Product> Products { get; set; }
    public DbSet<Customer.Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer.Customer>()
            .HasMany(e => e.Products)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerId)
            .IsRequired(false);
    }
}
