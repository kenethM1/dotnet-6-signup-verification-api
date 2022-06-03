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
    [AllowAnonymous]
    [HttpGet("/GetProductByCategory/{id}")]
    public ActionResult<List<ProductResponse>> GetProductByCategory(int id)
    {
        var response = _productsService.GetProductByCategory(id);
        return Ok(response);
    }
    [AllowAnonymous]
    [HttpPost("/removeProduct/{id}")]
    public ActionResult<ProductResponse> RemoveProduct(int id)
    {
        var response = _productsService.RemoveProduct(id);
        return Ok(response);
    }
    [AllowAnonymous]
    [HttpGet("/getAllSizes")]
    public ActionResult<List<SizeDTO>> GetSizeList()
    {
        var response = _productsService.GetAllSizes();
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("/getAllBrands")]
    public ActionResult<BrandResponse> getAllBrands()
    {
        var response = _productsService.GetAllBrands();
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("/insertListSizes")]
    public ActionResult<List<SizeDTO>> InsertListSize(SizeRequest request)
    {
        var response = _productsService.InsertListSizes(request);
        return Ok(response);
    }

}