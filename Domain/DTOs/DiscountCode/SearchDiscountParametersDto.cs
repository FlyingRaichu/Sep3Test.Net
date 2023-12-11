namespace Domain.DTOs.DiscountCode;

public class SearchDiscountParametersDto
{
    public string? CodeContains { get; }
    public int? DiscountPercentageContains { get; }

    public SearchDiscountParametersDto(string? codeContains, int? discountPercentageContains)
    {
        CodeContains = codeContains;
        DiscountPercentageContains = discountPercentageContains;
    }
}