using EShop.Entities;

namespace EShop.Services;

public class ProductService : IProductService
{
    private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Milk", Description = "1L, fresh", Price = 3m },
        new Product { Id = 2, Name = "Flavour", Description = "2Kg", Price = 5m },
        new Product { Id = 3, Name = "Kinoa", Description = "1Kg", Price = 10m },
        new Product { Id = 4, Name = "Water", Description = "1,5L Mineral", Price = 2m }
    };
    
    public async Task<List<Product>> GetAllProducts()
    {
        return await Task.FromResult(_products);
    }

    public async Task<Product> GetProductById(int productId)
    {
        var result = _products.FirstOrDefault(p => p.Id == productId);
        return await Task.FromResult(result);
    }

    public Task<Product> AddProduct(int productId,Product product)
    {
        /*var result = _products.FirstOrDefault(p => p.Id == productId);*/
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }
}