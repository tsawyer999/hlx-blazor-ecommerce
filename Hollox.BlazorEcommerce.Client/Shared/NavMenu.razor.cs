using Hollox.BlazorEcommerce.Client.Services;
using Hollox.BlazorEcommerce.Shared;
using Hollox.BlazorEcommerce.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Hollox.BlazorEcommerce.Client.Shared;

public partial class NavMenu
{
    [Inject]
    private ICategoryService CategoryService { get; set; } = default!;

    protected bool collapseNavMenu = true;
    protected List<Category> Categories { get; set; } = new();

    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    protected void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    protected override async Task OnInitializedAsync()
    {
        Categories = await CategoryService.GetCategoriesAsync();
    }
}