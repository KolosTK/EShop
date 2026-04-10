using EShop.Data;
using EShop.DTOs;
using EShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services;

public class ProductService : IProductService
{
    private readonly EShopContext _context;
    public ProductService(EShopContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProductResponseDTO>> GetAllProductsAsync()
    => await _context.Products.Select(c => new ProductResponseDTO
        {
            Id = c.Id,
            Name = c.Name,
            Price = c.Price,
            Description = c.Description,
            ImageUrl = c.ImageUrl
        }).ToListAsync();

    public async Task<ProductResponseDTO?> GetProductByIdAsync(int productId)
    {
        var result = await _context.Products.Where(c=>c.Id==productId).Select(
            c=>new ProductResponseDTO
            {
                Id = c.Id,
                Name = c.Name,
                Price = c.Price,
                Description = c.Description,
                ImageUrl = c.ImageUrl
            }).FirstOrDefaultAsync();
        return result;
    }

    public async Task<ProductResponseDTO> AddProductAsync (CreateProductRequestDTO product)
    {
        var newProduct = new Product
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            ImageUrl = product.ImageUrl
        };
        
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();
        
        return new ProductResponseDTO
        {
            Id = newProduct.Id,
            Name = newProduct.Name,
            Price = newProduct.Price,
            Description = newProduct.Description,
            ImageUrl = newProduct.ImageUrl
        };
    }

    public async Task<bool> UpdateProductAsync(int productId, UpdateProductRequestDTO product)
    {
        var existingProduct = await _context.Products.FindAsync(productId);
        if (existingProduct is null) return false;
        
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Description = product.Description;
        existingProduct.ImageUrl = product.ImageUrl;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        var deletingProduct = await _context.Products.FindAsync(productId);
        if (deletingProduct is null) return false;
        
        _context.Products.Remove(deletingProduct);
        
        await _context.SaveChangesAsync();
        return true;
    }
}