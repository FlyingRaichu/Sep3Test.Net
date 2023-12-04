namespace Domain.DTOs;

public class FavoriteDto
{
    public int UserId { get; set; }
    public int ItemId { get; set; }

    public FavoriteDto(int userId, int itemId)
    {
        UserId = userId;
        ItemId = itemId;
    }
}