using Hollox.BlazorEcommerce.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Hollox.BlazorEcommerce.Shared;

namespace Hollox.BlazorEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return Ok(await _productService.GetProductsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> GetProductById(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound("Product not found");
        }

        return Ok(product);
    }
}