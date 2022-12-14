using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorECommerce.Repository.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync();
    Task<List<Product>> GetProductsByCategorySlugAsync(string slug);
    Task<Product?> GetProductByIdAsync(int productId);

    Task<ProductSearch> GetProductsBySearchTermAsync(string description, int page, int size);
}