using OrderService.Web.Models;

namespace OrderService.Web.Services;

public sealed class InMemoryProductService : IProductService
{
    private static readonly IReadOnlyList<Product> Products =
    [
        new Product
        {
            Id = 1,
            Name = "Wireless Headphones",
            Category = "Electronics",
            Price = 129.99m,
            Description = "Noise-cancelling over-ear wireless headphones with 30-hour battery life.",
            ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?auto=format&fit=crop&w=900&q=80",
            Stock = 42
        },
        new Product
        {
            Id = 2,
            Name = "Smart Watch",
            Category = "Wearables",
            Price = 219.00m,
            Description = "Fitness-focused smart watch with heart-rate tracking and GPS.",
            ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?auto=format&fit=crop&w=900&q=80",
            Stock = 31
        },
        new Product
        {
            Id = 3,
            Name = "Portable Bluetooth Speaker",
            Category = "Audio",
            Price = 89.50m,
            Description = "Compact waterproof speaker with rich bass and 12-hour playtime.",
            ImageUrl = "https://images.unsplash.com/photo-1589003077984-894e133dabab?auto=format&fit=crop&w=900&q=80",
            Stock = 18
        },
        new Product
        {
            Id = 4,
            Name = "Mechanical Keyboard",
            Category = "Accessories",
            Price = 109.00m,
            Description = "RGB mechanical keyboard with tactile switches for precision typing.",
            ImageUrl = "https://images.unsplash.com/photo-1511467687858-23d96c32e4ae?auto=format&fit=crop&w=900&q=80",
            Stock = 26
        }
    ];

    public IReadOnlyList<Product> GetAll() => Products;

    public Product? GetById(int id) => Products.FirstOrDefault(p => p.Id == id);
}
