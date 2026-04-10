using EShop.Entities;
using EShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductService  _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
       return await _productService.GetAllProducts(); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int productId)
    {
        var result = await _productService.GetProductById(productId);
        if (result is null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}