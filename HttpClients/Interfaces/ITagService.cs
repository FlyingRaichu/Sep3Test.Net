using Domain.DTOs.Tag;

namespace HttpClients.Interfaces;

public interface ITagService
{
    Task<ICollection<Tag>> GetTagsAsync(string? name);
    Task<Tag> CreateAsync(TagCreationDto dto);
    Task UpdateAsync(TagUpdateDto dto);
    Task DeleteAsync(int id);
    Task<Tag> GetByIdAsync(int id);
    Task<ICollection<Tag>> GetAllWithId(List<int> ids);
}