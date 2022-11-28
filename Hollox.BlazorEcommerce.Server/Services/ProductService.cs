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

    public async Task<List<Product>> GetProductsByCategorySlugAsync(string slug)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Where(p => p.Category!.Slug == slug)
            .ToListAsync();
    }

    public async Task<Product?> GetProductById(int productId)
    {
        return await _context.Products.FindAsync(productId);
    }
}