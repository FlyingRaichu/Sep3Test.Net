using Domain.DTOs.FullName;
using proto;

namespace Application.DaoInterfaces;

public interface IFullNameDao
{
    Task<IEnumerable<FullName>> GetAsync(SearchFullNameParametersDto searchParameters);
    Task<FullName> CreateAsync(FullName fullName);
    Task<FullName?> GetFullNameById(int id);
}