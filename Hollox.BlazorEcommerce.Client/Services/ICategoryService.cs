using Hollox.BlazorEcommerce.Shared;

namespace Hollox.BlazorEcommerce.Client.Services;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync();
}