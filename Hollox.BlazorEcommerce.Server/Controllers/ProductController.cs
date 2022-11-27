using Hollox.BlazorEcommerce.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Hollox.BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hollox.BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ECommerceDataContext _context;

        public ProductController(ECommerceDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var product = await _context.Products.ToListAsync();

            return Ok(product);
        }
    }
}
