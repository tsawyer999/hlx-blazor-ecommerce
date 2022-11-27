using Hollox.BlazorEcommerce.Shared;

namespace Hollox.BlazorEcommerce.Client.Services;

public interface IProductService
{
    Task<List<Product>> GetProducts();
}