using Domain.DTOs.Tag;

namespace Application.DaoInterfaces;

public interface ITagDao
{
    Task<IEnumerable<Tag>> GetAsync(SearchTagParametersDto searchParameters);
    Task<Tag> CreateAsync(Tag tag);
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(int id);
    Task<Tag?> GetByIdAsync(int id);
    Task<IEnumerable<Tag>> GetAllWithIdAsync(List<int> ids);
}