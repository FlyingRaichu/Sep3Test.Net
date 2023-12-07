namespace Domain.DTOs.Review;

public class ReviewCreationDto
{
    public string Content { get; }
    public int Rating { get; }
    public string Username { get; }
    public int ItemId { get; }

    public ReviewCreationDto(string content, int rating, string username, int itemId)
    {
        Content = content;
        Rating = rating;
        Username = username;
        ItemId = itemId;
    }
}