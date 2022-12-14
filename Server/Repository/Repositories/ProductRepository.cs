using Hollox.BlazorECommerce.Repository.Data;
using Hollox.BlazorEcommerce.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hollox.BlazorECommerce.Repository.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ECommerceDataContext _context;

    public ProductRepository(ECommerceDataContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products
            .Include(p => p.Variants)
            .ToListAsync();
    }

    public async Task<List<Product>> GetProductsByCategorySlugAsync(string slug)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Where(p => p.Category!.Slug == slug)
            .Include(p => p.Variants)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await _context.Products
            .Include(p => p.Variants)
            .ThenInclude(v => v.ProductType)
            .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<ProductSearch> GetProductsBySearchTermAsync(string term, int page, int size)
    {
        var loweredTerm = term.ToLower();

        var results = Task.WhenAll(Task.Run(() => _context.Products
                .Where(p => p.Title.ToLower().Contains(loweredTerm) ||
                            p.Description.ToLower().Contains(loweredTerm))),

            Task.Run(() => _context.Products
                .Where(p => p.Title.ToLower().Contains(loweredTerm) ||
                            p.Description.ToLower().Contains(loweredTerm))
                .Include(p => p.Variants)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync())
        );

        return new ProductSearch();
    }
}