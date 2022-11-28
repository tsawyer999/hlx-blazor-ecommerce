using Hollox.BlazorEcommerce.Shared;

namespace Hollox.BlazorEcommerce.Server.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<List<Product>> GetProductsByCategorySlugAsync(string slug);
    Task<Product?> GetProductById(int productId);
}