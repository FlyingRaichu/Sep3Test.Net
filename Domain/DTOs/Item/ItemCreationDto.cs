namespace Domain.DTOs.Item;

public class ItemCreationDto
{
    public string Title { get; }
    public string Description { get; }
    public double Price { get; }
    public string Manufacturer { get; }
    public int Stock { get; }
    public List<int> Tags { get; }

    public ItemCreationDto(string title, string description, double price, string manufacturer, int stock, List<int> tags)
    {
        Title = title;
        Description = description;
        Price = price;
        Manufacturer = manufacturer;
        Stock = stock;
        Tags = tags;
    }

    public ItemCreationDto(string title, string description, double price, string manufacturer, int stock)
    {
        Title = title;
        Description = description;
        Price = price;
        Manufacturer = manufacturer;
        Stock = stock;
        Tags = new List<int>();
    }
}