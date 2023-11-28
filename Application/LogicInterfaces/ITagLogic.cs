using Domain.DTOs.Tag;
using MudBlazor;

namespace Application.LogicInterfaces;

public interface ITagLogic
{
    Task<IEnumerable<Tag>> GetAsync(SearchTagParametersDto searchParameters);
    Task<Tag> CreateAsync(TagCreationDto dto);
    Task UpdateAsync(TagUpdateDto dto);
    Task DeleteAsync(int id);
    Task<Tag> GetByIdAsync(int id);
}