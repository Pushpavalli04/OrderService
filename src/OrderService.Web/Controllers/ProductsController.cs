using Microsoft.AspNetCore.Mvc;
using OrderService.Web.Services;

namespace OrderService.Web.Controllers;

[Route("products")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id:int}")]
    public IActionResult Details(int id)
    {
        var product = _productService.GetById(id);        

        return View(product);
    }
}
