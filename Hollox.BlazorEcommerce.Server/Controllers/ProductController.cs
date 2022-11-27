using Hollox.BlazorEcommerce.Server.Data;
using Hollox.BlazorEcommerce.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Hollox.BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hollox.BlazorEcommerce.Server.Controllers
{
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
    }
}
