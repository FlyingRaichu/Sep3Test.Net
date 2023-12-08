namespace Domain.DTOs.DiscountCode;
using System.Text.Json.Serialization;

public class DiscountCodeDto
{
    public int Id { get;  }
    public string Code { get;  }
    public int DiscountPercentage { get;  }

    [JsonConstructor]
    public DiscountCodeDto(int id, string code, int discountPercentage)
    {
        Id = id;
        Code = code;
        DiscountPercentage = discountPercentage;
    }
    
}