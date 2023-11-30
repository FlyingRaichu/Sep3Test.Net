namespace Domain.DTOs.Review;

public class ReviewCreationDto
{
    public string Content { get; }
    public int Rating { get; }
    public string Username { get; }

    public ReviewCreationDto(string content, int rating, string username)
    {
        Content = content;
        Rating = rating;
        Username = username;
    }
}