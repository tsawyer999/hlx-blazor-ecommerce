using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorECommerce.Business.Services;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync();
}