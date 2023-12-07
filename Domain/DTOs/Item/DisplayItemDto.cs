namespace Domain.DTOs.Item;

public class DisplayItemDto
{
    public string Title { get; }
    public string Description { get; }
    public double Price { get; }
    public string Manufacturer { get; }
    public int Stock { get; }
    
    public List<string> Tags { get; }
    public double DiscountPercentage { get; }

    public DisplayItemDto(string title, string description, double price, string manufacturer, int stock, List<int> tags, double discountPercentage)
    {
        Title = title;
        Description = description;
        Price = price;
        Manufacturer = manufacturer;
        Stock = stock;
        DiscountPercentage = discountPercentage;
    }
}