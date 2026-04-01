using EShop.Data;
using Microsoft.EntityFrameworkCore;

namespace EShop;

public class Program
{
    public static void Main(string[] args)
    {
        
        
        var builder = WebApplication.CreateBuilder(args);

        /*builder.Configuration.SetBasePath(DirectoryBrowserExtensions.GetCurrentDirectory()).AddJsonFile("secrets.json");*/
        
        builder.Services.AddDbContext<EShopContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        
        
        builder.Services.AddRazorPages();

        
        
        var app = builder.Build();

        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
            .WithStaticAssets();

        app.Run();
    }
}