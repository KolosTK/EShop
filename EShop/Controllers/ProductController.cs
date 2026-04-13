using EShop.DTOs;
using EShop.Entities;
using EShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductService  _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductResponseDTO>>> GetAllProducts()
    {
        return Ok(await _productService.GetAllProductsAsync()); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseDTO>> GetProductById(int productId)
    {
        var result = await _productService.GetProductByIdAsync(productId);
        if (result is null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateProductRequestDTO>> AddProduct(CreateProductRequestDTO product)
    {
        var result = await _productService.AddProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, UpdateProductRequestDTO product)
    {
        var result = await _productService.UpdateProductAsync(id, product);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var deleted = await _productService.DeleteProductAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}