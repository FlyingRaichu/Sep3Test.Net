namespace Domain.DTOs.Item;

public class ItemUpdateDto
{
    public int Id { get; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }

    public ItemUpdateDto(int id)
    {
        Id = id;
    }
}