namespace Domain.DTOs.FullName;

public class SearchFullNameParametersDto
{
    public string FirstName { get; }
    public string? MiddleName { get; }
    public string LastName { get; }

    public SearchFullNameParametersDto(string firstName, string? middleName, string lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }
}