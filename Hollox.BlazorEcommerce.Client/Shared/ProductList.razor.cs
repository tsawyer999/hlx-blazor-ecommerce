using Hollox.BlazorEcommerce.Client.Services;
using Hollox.BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;

namespace Hollox.BlazorEcommerce.Client.Shared;

public partial class ProductList
{
    [Inject]
    private IProductService ProductService { get; set; } = default!;

    protected List<Product> Products = new();

    protected override async Task OnInitializedAsync()
    {
        Products = await ProductService.GetProducts();
    }
}