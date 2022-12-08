using Hollox.BlazorEcommerce.Client.Services;
using Hollox.BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;

namespace Hollox.BlazorEcommerce.Client.Pages;

public partial class ProductDetails
{
    protected Product? Product;
    protected int CurrentTypeId;
    protected ProductVariant? SelectedVariant;

    [Inject]
    private IProductService ProductService { get; set; } = default!;

    [Parameter]
    public int Id { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        Product = await ProductService.GetProductByIdAsync(Id);
        var firstVariant = Product?.Variants.FirstOrDefault();
        CurrentTypeId = firstVariant?.ProductTypeId ?? -1;
    }

    protected void OnProductVariantChange(ChangeEventArgs e)
    {
        if (Product == null)
        {
            return;
        }

        if (e.Value == null)
        {
            return;
        }

        if (!int.TryParse(e.Value.ToString(), out var selectedVariantId))
        {
            return;
        }

        SelectedVariant = Product.Variants.Find(v => v.ProductTypeId == selectedVariantId);
        Console.WriteLine("It is definitely: " + SelectedVariant);
    }
}