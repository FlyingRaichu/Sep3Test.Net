namespace Domain.DTOs.Item;

public class ItemCreationDto
{
    public string Title { get; }
    public string Manufacture { get; }
    public string Description { get; }
    public double Price { get; }
    public int Stock { get; }

    public ItemCreationDto(string title, string manufacture, string description, double price, int stock)
    {
        Title = title;
        Manufacture = manufacture;
        Description = description;
        Price = price;
        Stock = stock;
    }
}