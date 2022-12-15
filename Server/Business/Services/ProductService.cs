using Hollox.BlazorECommerce.Repository.Repositories;
using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorECommerce.Business.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _productRepository.GetProductsAsync();
    }

    public async Task<List<Product>> GetProductsByCategorySlugAsync(string slug)
    {
        return await _productRepository.GetProductsByCategorySlugAsync(slug);
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await _productRepository.GetProductByIdAsync(productId);
    }

    public async Task<ProductSearch> GetProductsBySearchTermAsync(string term, int page, int size)
    {
        return await _productRepository.GetProductsBySearchTermAsync(term, page, size);
    }
}