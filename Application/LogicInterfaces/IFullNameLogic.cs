using Domain.DTOs.FullName;
using proto;

namespace Application.LogicInterfaces;

public interface IFullNameLogic
{
    Task<IEnumerable<FullName>> GetAsync(SearchFullNameParametersDto searchParameters);
    Task<FullName> CreateAsync(FullNameCreationDto dto);
}