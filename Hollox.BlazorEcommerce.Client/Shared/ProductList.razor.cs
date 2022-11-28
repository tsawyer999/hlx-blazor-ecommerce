using Hollox.BlazorEcommerce.Client.Services;
using Hollox.BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;

namespace Hollox.BlazorEcommerce.Client.Shared;

public partial class ProductList
{
    [Inject]
    private IProductService ProductService { get; set; } = default!;

    [Parameter]
    public string CategorySlug { get; set; }

    protected List<Product> Products = new();

    protected override async Task OnParametersSetAsync()
    {
        if (string.IsNullOrWhiteSpace(CategorySlug))
        {
            Products = await ProductService.GetProductsAsync();
        }
        else
        {
            Products = await ProductService.GetProductsByCategorySlugAsync(CategorySlug);
        }
    }
}