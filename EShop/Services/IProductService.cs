using EShop.DTOs;
using EShop.Entities;

namespace EShop.Services;

public interface IProductService
{
    public Task<List<ProductResponseDTO>> GetAllProductsAsync();
    public Task<ProductResponseDTO?> GetProductByIdAsync(int productId);
    public Task<ProductResponseDTO?> AddProductAsync( CreateProductRequestDTO product);
    public Task<bool> UpdateProductAsync(int productId, UpdateProductRequestDTO product);
    public Task<bool> DeleteProductAsync(int productId);
    
}