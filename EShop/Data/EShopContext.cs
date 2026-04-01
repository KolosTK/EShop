using EShop.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data;

public class EShopContext : IdentityDbContext
{
    public EShopContext(DbContextOptions<EShopContext> options) 
        :base(options)
    {
    }
    
    private DbSet<Product> Products { get; set; }

    /*protected override void OnModelCreating(ModelBuilder builder)
    {
    }*/
}