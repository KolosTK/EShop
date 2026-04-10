using EShop.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data;

public class EShopContext : DbContext
{
    public EShopContext(DbContextOptions<EShopContext> options) 
        :base(options)
    {
    }
    
    private DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 2);
        });
    }
}