using System.ComponentModel.DataAnnotations;

namespace EShop.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}