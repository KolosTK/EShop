using EShop.Entities;

namespace EShop.Services;

public interface IProductService
{
    public Task<List<Product>> GetAllProducts();
    public Task<Product?> GetProductById(int productId);
    public Task<Product?> AddProduct(int productId, Product product);
    public Task<bool> UpdateProduct(Product product);
    public Task<bool> DeleteProduct(int productId);
    
}