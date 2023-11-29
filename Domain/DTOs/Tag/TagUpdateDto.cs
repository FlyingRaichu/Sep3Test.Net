namespace Domain.DTOs.Tag;

public class TagUpdateDto
{
    public int Id { get; }
    public string Name { get; set; }

    public TagUpdateDto(int id)
    {
        Id = id;
    }
}