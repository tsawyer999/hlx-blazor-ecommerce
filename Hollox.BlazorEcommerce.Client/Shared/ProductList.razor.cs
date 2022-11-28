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

    protected string GetPriceText(Product product)
    {
        var variants = product.Variants;
        if (variants.Count == 0)
        {
            return string.Empty;
        }

        if (variants.Count == 1)
        {
            return $"{variants[0].Price} $";
        }

        var minPrice = 0m;
        var maxPrice = 0m;
        foreach (var variant in product.Variants)
        {
            if (variant.Price < minPrice)
            {
                minPrice = variant.Price;
            }
            else if (variant.Price > maxPrice)
            {
                maxPrice = variant.Price;
            }
        }

        return $"Start from {minPrice:C} $ to {maxPrice:C} $";
    }
}