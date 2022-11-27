using Hollox.BlazorEcommerce.Server.Data;
using Hollox.BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hollox.BlazorEcommerce.Server.Services;

public class ProductService : IProductService
{
    private readonly ECommerceDataContext _context;

    public ProductService(ECommerceDataContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
}