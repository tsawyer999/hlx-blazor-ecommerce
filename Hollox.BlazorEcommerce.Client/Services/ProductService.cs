using System.Net.Http.Json;
using Hollox.BlazorEcommerce.Shared;

namespace Hollox.BlazorEcommerce.Client.Services;

public class ProductService : IProductService
{
    private const string ECommerceApiBaseURl = "https://localhost:7226";
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Product>> GetProducts()
    {
        try
        {
            var products = await _http.GetFromJsonAsync<List<Product>>($"{ECommerceApiBaseURl}/api/product") ?? new List<Product>();

            return products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Product>();
        }
    }

    public async Task<Product?> GetProductById(int id)
    {
        try
        {
            return await _http.GetFromJsonAsync<Product>($"{ECommerceApiBaseURl}/api/product/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }
}