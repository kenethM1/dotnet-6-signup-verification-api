using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;


[Authorize]
[ApiController]
[Route("[controller]")]
public class CategoryController : BaseController
{
    private readonly ICategoriesService _categoriesService;
    public CategoryController(ICategoriesService _categoriesService)
    {
        this._categoriesService = _categoriesService;
    }

    [AllowAnonymous]
    [HttpGet("/GetAllCategories")]
    public IActionResult GetCategories()
    {
        var response = _categoriesService.GetAll();
        return Ok(response);
    }
    [AllowAnonymous]
    [HttpPost("/CreateCategory")]
    public IActionResult CreateCategory(CategoryRequest request)
    {
        var response = _categoriesService.Create(request);
        return Ok(response);
    }
}