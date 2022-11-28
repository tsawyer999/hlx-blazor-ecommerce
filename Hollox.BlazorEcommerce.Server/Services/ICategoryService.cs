using Hollox.BlazorEcommerce.Shared;

namespace Hollox.BlazorEcommerce.Server.Services;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync();
}