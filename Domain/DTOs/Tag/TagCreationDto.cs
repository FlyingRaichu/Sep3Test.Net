namespace Domain.DTOs.Tag;

public class TagCreationDto
{
    public string Name { get; }


    public TagCreationDto(string name)
    {
        Name = name;
    }
}