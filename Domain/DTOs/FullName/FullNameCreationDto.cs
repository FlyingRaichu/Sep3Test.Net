namespace Domain.DTOs.FullName;

public class FullNameCreationDto
{
    public string FirstName { get; }
    public string? MiddleName { get; }
    public string LastName { get; }

    public FullNameCreationDto(string firstName, string? middleName, string lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }
}