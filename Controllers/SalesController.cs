namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Accounts;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]

public class SalesController : BaseController
{
    private readonly ISalesService _salesService;

    public SalesController(ISalesService salesService)
    {
        _salesService = salesService;
    }

    [AllowAnonymous]
    [HttpGet("/GetAllSales")]
    public ActionResult<OrdersResponse> GetOrders(string userId){
        var response = _salesService.GetMyOrders(userId);
        return Ok(response);
    }
}