using Hollox.BlazorEcommerce.Server.Data;
using Hollox.BlazorEcommerce.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hollox.BlazorEcommerce.Server.Services;

public class CategoryService : ICategoryService
{
    private readonly ECommerceDataContext _context;

    public CategoryService(ECommerceDataContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }
}