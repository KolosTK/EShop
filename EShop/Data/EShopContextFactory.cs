using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EShop.Data;


public class EShopContextFactory : IDesignTimeDbContextFactory<EShopContext>
{
    public EShopContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();

        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        Console.WriteLine("=== DEBUG ===");
        Console.WriteLine($"BasePath: {basePath}");
        Console.WriteLine($"ConnectionString: {connectionString}");
        Console.WriteLine("=============");

        // test the connection right here
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            Console.WriteLine("SQL connection from factory: OK");
        }

        var optionsBuilder = new DbContextOptionsBuilder<EShopContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new EShopContext(optionsBuilder.Options);
    }
}
