using Microsoft.AspNetCore.Components;

namespace Hollox.BlazorEcommerce.Client.Pages;

public partial class Index
{
    [Parameter]
    public string? CategorySlug { get; set; }
}