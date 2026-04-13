using EShop.Controllers;
using EShop.DTOs;
using EShop.Entities;
using EShop.Services;
using FakeItEasy.Sdk;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EShop.Tests;

public class ProductControllerTest
{
    [Fact]
    public async Task GetProductById_ProductExist_ReturnsCreatedAtAction()
    {
        //Arrange
        var mockService = new Mock<IProductService>();

        var product = new ProductResponseDTO()
        {
            Id = 1,
            Name = "Product 1",
            Price = 100,
            ImageUrl = "ImageUrl",
        };
        
        mockService
            .Setup(s=>s.GetProductByIdAsync(1))
            .ReturnsAsync(product);
        
        var constructor = new ProductController(mockService.Object);
        
        //Act
        
        var result = await constructor.GetProductById(1);
        
        //Assert
        var actionResult = Assert.IsType<ActionResult<ProductResponseDTO>>(result);
        var okResult =  Assert.IsType<OkObjectResult>(actionResult.Result);
        
        var returnValue = Assert.IsType<ProductResponseDTO>(okResult.Value);
        
        Assert.Equal(product.Id, returnValue.Id);
        Assert.Equal(product.Name, returnValue.Name);
        Assert.Equal(product.Price, returnValue.Price);
        Assert.Equal(product.ImageUrl, returnValue.ImageUrl);
    }
}