namespace Domain.DTOs;

public class SearchItemParametersDto
{
    public string? TitleContains { get; }
    public string? DescriptionContains { get; }
    public double? Price { get; }
    public string? ManufacturerContains { get; }
    public int? Stock { get;}
    
    public List<int>? ContainsTags { get;}
    public double? DiscountPercentage { get; }

    public SearchItemParametersDto(string? titleContains, string? descriptionContains, double? price, string? manufacturerContains, int? stock, List<int>? containsTags,double? discountPercentage)
    {
        TitleContains = titleContains;
        DescriptionContains = descriptionContains;
        Price = price;
        ManufacturerContains = manufacturerContains;
        Stock = stock;
        ContainsTags = containsTags;
        DiscountPercentage = discountPercentage;
    }
}