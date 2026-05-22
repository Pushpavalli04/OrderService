using OrderService.Web.Services;

namespace OrderService.Web.Tests;

public class ProductServiceTests
{
    [Fact]
    public void GetAll_ReturnsSeededProducts()
    {
        var service = new InMemoryProductService();

        var products = service.GetAll();

        Assert.NotEmpty(products);
        Assert.True(products.Count >= 4);
    }

    [Fact]
    public void GetById_ReturnsNull_ForUnknownId()
    {
        var service = new InMemoryProductService();

        var product = service.GetById(999);

        Assert.Null(product);
    }
}
