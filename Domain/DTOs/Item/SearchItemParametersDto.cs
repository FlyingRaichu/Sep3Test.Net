namespace Domain.DTOs;

public class SearchItemParametersDto
{
    public string? TitleContains { get; }
    public string? DescriptionContains { get; }
    public double? Price { get; }

    public SearchItemParametersDto(string? titleContains, string? descriptionContains, double? price)
    {
        TitleContains = titleContains;
        DescriptionContains = descriptionContains;
        Price = price;
    }
}