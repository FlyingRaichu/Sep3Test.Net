namespace Domain.DTOs.DiscountCode;
using System.Text.Json.Serialization;

public class DiscountCodeDto
{
    
    public string Code { get; set; }
    public int DiscountPercentage { get; set; }

    [JsonConstructor]
    public DiscountCodeDto(string code, int discountPercentage)
    {
        
        Code = code;
        DiscountPercentage = discountPercentage;
    }
    
}