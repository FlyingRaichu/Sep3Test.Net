using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.FullName;
using proto;

namespace Application.Logic;

public class FullNameLogic : IFullNameLogic
{
    private readonly IFullNameDao fullNameDao;

    public FullNameLogic(IFullNameDao fullNameDao)
    {
        this.fullNameDao = fullNameDao;
    }

    public Task<IEnumerable<FullName>> GetAsync(SearchFullNameParametersDto searchParameters)
    {
        return fullNameDao.GetAsync(searchParameters);
    }

    public async Task<FullName> CreateAsync(FullNameCreationDto dto)
    {
        ValidateFullName(dto);
        var fullName = new FullName
        {
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName
        };
        var created = await fullNameDao.CreateAsync(fullName);
        return created;
    }

    private void ValidateFullName(FullNameCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.FirstName) || string.IsNullOrEmpty(dto.LastName))
        {
            throw new Exception("First and Last name must be filled out");
        }
    }
}