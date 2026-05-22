namespace OrderService.Web.Models;

public sealed class Product
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public required string Category { get; init; }

    public decimal Price { get; init; }

    public required string Description { get; init; }

    public required string ImageUrl { get; init; }

    public int Stock { get; init; }
}
