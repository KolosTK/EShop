namespace EShop.DTOs;

public class CreateProductRequestDTO
{ 
    public string Name { get; set; }    = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }  = string.Empty;
    
}