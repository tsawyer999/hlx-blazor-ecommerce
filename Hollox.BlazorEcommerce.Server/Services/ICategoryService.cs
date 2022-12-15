using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorEcommerce.Server.Services;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync();
}