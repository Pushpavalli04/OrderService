using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrderService.Web.Models;
using OrderService.Web.Services;

namespace OrderService.Web.Controllers;

[Route("[controller]")]
public class HomeController : Controller
{
    private readonly IProductService _productService;

    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("/")]
    [HttpGet("[action]")]
    public IActionResult Index()
    {
        var products = _productService.GetAll();
        return View(products);
    }

    [HttpGet("[action]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
