using OrderService.Web.Models;

namespace OrderService.Web.Services;

public interface IProductService
{
    IReadOnlyList<Product> GetAll();

    Product? GetById(int id);
}
