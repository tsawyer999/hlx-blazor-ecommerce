using Hollox.BlazorEcommerce.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Hollox.BlazorEcommerce.Shared;

namespace Hollox.BlazorEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetProducts()
    {
        return Ok(await _categoryService.GetCategoriesAsync());
    }
}