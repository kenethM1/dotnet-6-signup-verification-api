namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Accounts;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]

public class ProductsController : BaseController
{

    public ProductsController()
    {
        
    }

[AllowAnonymous]
[HttpGet("/categories")]
    public IActionResult GetCategories()
    {
        
        return Ok(new { message = "Token revoked" });
    }
}