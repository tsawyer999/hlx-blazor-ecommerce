using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorEcommerce.Client.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<List<Product>> GetProductsByCategorySlugAsync(string slug);
    Task<List<Product>> GetProductByTerm(string term);
    Task<Product?> GetProductByIdAsync(int id);
}