namespace Domain.DTOs;

public class SearchItemParametersDto
{
    public string? TitleContains { get; }
    public string? ManufactureContains { get; }
    public string? DescriptionContains { get; }
    public double? Price { get; }
    public int? Stock { get; }

    public SearchItemParametersDto(string? titleContains, string? manufactureContains, string? descriptionContains, double? price, int? stock)
    {
        TitleContains = titleContains;
        ManufactureContains = manufactureContains;
        DescriptionContains = descriptionContains;
        Price = price;
        Stock = stock;
    }
}