using System.Net.Http.Json;
using Hollox.BlazorEcommerce.Client.Models;
using Hollox.BlazorEcommerce.Shared.Models;

namespace Hollox.BlazorEcommerce.Client.Services;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _http;
    private readonly AppSettings _appSettings;

    public CategoryService(HttpClient http, AppSettings appSettings)
    {
        _http = http;
        _appSettings = appSettings;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        try
        {
            var categories = await _http.GetFromJsonAsync<List<Category>>($"{_appSettings.ECommerceApiUrl}/category") ?? new List<Category>();

            return categories;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Category>();
        }
    }
}