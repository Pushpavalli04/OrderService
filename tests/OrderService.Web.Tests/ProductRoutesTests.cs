using Microsoft.AspNetCore.Mvc.Testing;

namespace OrderService.Web.Tests;

public class ProductRoutesTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ProductRoutesTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task HomePage_ReturnsSuccess()
    {
        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/");

        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task ProductDetails_ReturnsNotFound_ForUnknownProduct()
    {
        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/products/999");

        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}
