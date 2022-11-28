﻿using Hollox.BlazorEcommerce.Client.Services;
using Hollox.BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;

namespace Hollox.BlazorEcommerce.Client.Pages;

public partial class ProductDetails
{
    protected Product? Product;
    protected int CurrentTypeId;

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
}