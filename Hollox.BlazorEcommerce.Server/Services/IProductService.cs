using Hollox.BlazorEcommerce.Shared;

namespace Hollox.BlazorEcommerce.Server.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<Product?> GetProductById(int id);
}