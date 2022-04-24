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
    private readonly IProductsService _productsService;
    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }
    
    [AllowAnonymous]
    [HttpGet("/GetAllProducts")]
    public ActionResult<List<ProductResponse>> GetProducts()
    {
        var response = _productsService.GetAll();
        return Ok(response);
    }
    [AllowAnonymous]
    [HttpPost("/CreateProduct")]
    public ActionResult<ProductResponse> CreateProduct(ProductsRequest request)
    {
        var response = _productsService.CreateProduct(request);
        return Ok(response);
    }
}