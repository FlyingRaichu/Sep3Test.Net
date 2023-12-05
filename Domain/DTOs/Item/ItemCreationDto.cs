using System.Text.Json.Serialization;

namespace Domain.DTOs.Item;

public class ItemCreationDto
{
    public string Title { get; }
    public string Description { get; }
    public double Price { get; }
    public string Manufacturer { get; }
    public int Stock { get; }
    
    public double DiscountPercentage { get; }
    public List<int>? Tags { get; }

    [JsonConstructor]
    public ItemCreationDto(string title, string description, double price, string manufacturer, int stock,
        List<int>? tags, double discountPercentage)
    {
        Title = title;
        Description = description;
        Price = price;
        Manufacturer = manufacturer;
        Stock = stock;
        Tags = tags ?? new List<int>();
        DiscountPercentage = discountPercentage;
    }
}