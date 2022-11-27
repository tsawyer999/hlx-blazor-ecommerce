using System.Net.Http.Json;

namespace Hollox.BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {
        private List<Product> Products = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                using var http = new HttpClient();

                Console.WriteLine("100");
                Products = await http.GetFromJsonAsync<List<Product>>("https://localhost:7226/api/product") ?? new List<Product>();
                Console.WriteLine("200");

                Console.WriteLine("products");
                Console.WriteLine(Products);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Products = new List<Product>();
            }
        }
    }
}
