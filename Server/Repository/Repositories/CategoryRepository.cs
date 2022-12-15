using Hollox.BlazorECommerce.Repository.Data;
using Hollox.BlazorEcommerce.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hollox.BlazorECommerce.Repository.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ECommerceDataContext _context;

    public CategoryRepository(ECommerceDataContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }
}