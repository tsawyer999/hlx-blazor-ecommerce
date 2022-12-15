using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorECommerce.Business.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<List<Product>> GetProductsByCategorySlugAsync(string slug);
    Task<Product?> GetProductByIdAsync(int productId);

    Task<ProductSearch> GetProductsBySearchTermAsync(string description, int page, int size);
}