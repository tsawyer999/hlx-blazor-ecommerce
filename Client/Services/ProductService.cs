using System.Net.Http.Json;
using Hollox.BlazorEcommerce.Client.Models;
using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorEcommerce.Client.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _http;
    private readonly AppSettings _appSettings;

    public ProductService(HttpClient http, AppSettings appSettings)
    {
        _http = http;
        _appSettings = appSettings;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            var products = await _http.GetFromJsonAsync<List<Product>>($"{_appSettings.ECommerceApiUrl}/product") ?? new List<Product>();

            return products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Product>();
        }
    }

    public async Task<List<Product>> GetProductsByCategorySlugAsync(string slug)
    {
        try
        {
            var products = await _http.GetFromJsonAsync<List<Product>>($"{_appSettings.ECommerceApiUrl}/product/category/{slug}") ?? new List<Product>();

            return products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Product>();
        }
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        try
        {
            return await _http.GetFromJsonAsync<Product>($"{_appSettings.ECommerceApiUrl}/product/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public async Task<List<Product>> GetProductByTerm(string term)
    {
        try
        {
            var products = await _http.GetFromJsonAsync<List<Product>>($"{_appSettings.ECommerceApiUrl}/search/{term}") ?? new List<Product>();

            return products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Product>();
        }
    }
}