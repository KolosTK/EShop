using EShop.Data;
using EShop.Entities;
using EShop.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EShop.Tests;

public class ProductServiceTest
{
    private EShopContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<EShopContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new EShopContext(options);
    }

    [Fact]
    public async Task ProductService_GetProductByIdAsync_ReturnProduct()
    {
        //Arrange
        var context = GetDbContext();

        context.Products.Add(new Product
        {
            Id = 1,
            Name = "Test Product",
            Price = 100,
            Description = "Test Description",
            ImageUrl = "Test ImageUrl"
        });
        
        await context.SaveChangesAsync();
        
        var service = new ProductService(context);
        
        //Act
        var result = await service.GetProductByIdAsync(1);
        
        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test Product", result.Name);
        Assert.Equal(100, result.Price);
        Assert.Equal("Test Description", result.Description);
        Assert.Equal("Test ImageUrl", result.ImageUrl);
    }

    [Fact]
    public async Task ProductService_GetProductByIdAsync_ReturnNull()
    {
        //Arrange
        var context = GetDbContext();
        var service = new ProductService(context);
        
        //Act 
        var result = await service.GetProductByIdAsync(1);
        
        //Assert
        Assert.Null(result);
    }
}