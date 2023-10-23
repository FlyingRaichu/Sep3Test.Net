namespace Domain.DTOs;

public class ItemCreationDto
{
    public string Title { get; }
    public string Description { get; }
    public double Price { get; }

    public ItemCreationDto(string title, string description, double price)
    {
        Title = title;
        Description = description;
        Price = price;
    }
}