using System.Net.Http.Json;
using Hollox.BlazorEcommerce.Shared;

namespace Hollox.BlazorEcommerce.Client.Services;

public class CategoryService : ICategoryService
{
    private const string ECommerceApiBaseURl = "https://localhost:7226/api";
    private readonly HttpClient _http;

    public CategoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        try
        {
            var categories = await _http.GetFromJsonAsync<List<Category>>($"{ECommerceApiBaseURl}/category") ?? new List<Category>();

            return categories;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Category>();
        }
    }
}