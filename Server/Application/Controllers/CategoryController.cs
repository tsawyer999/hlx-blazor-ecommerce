using Hollox.BlazorECommerce.Business.Services;
using Hollox.BlazorEcommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hollox.BlazorEcommerce.Application.Controllers;

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