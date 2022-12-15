using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorEcommerce.Client.Services;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync();
}