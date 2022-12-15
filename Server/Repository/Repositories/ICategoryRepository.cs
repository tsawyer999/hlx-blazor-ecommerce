using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorECommerce.Repository.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();
}