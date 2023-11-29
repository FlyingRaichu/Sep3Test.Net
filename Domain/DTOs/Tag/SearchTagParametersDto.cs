namespace Domain.DTOs.Tag;

public class SearchTagParametersDto
{
    public string? NameContains { get; }

    public SearchTagParametersDto(string? nameContains)
    {
        NameContains = nameContains;
    }
}