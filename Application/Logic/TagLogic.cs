using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.Tag;

namespace Application.Logic;

public class TagLogic : ITagLogic
{
    private readonly ITagDao tagDao;

    public TagLogic(ITagDao tagDao)
    {
        this.tagDao = tagDao;
    }

    public Task<IEnumerable<Tag>> GetAsync(SearchTagParametersDto searchParameters)
    {
        return tagDao.GetAsync(searchParameters);
    }

    public async Task<Tag> CreateAsync(TagCreationDto dto)
    {
        ValidateTag(dto);
        var tag = new Tag
        {
            TagName = dto.Name
        };
        var created = await tagDao.CreateAsync(tag);
        return created;
    }

    public async Task UpdateAsync(TagUpdateDto dto)
    {
        Tag existing = await GetByIdAsync(dto.Id);

        string nameToUse = dto.Name ?? existing.TagName;

        Tag updated = new()
        {
            Id = existing.Id,
            TagName = nameToUse
        };
        
        ValidateTag(updated);
        await tagDao.UpdateAsync(updated);
    }

    public async Task DeleteAsync(int id)
    {
        await tagDao.DeleteAsync(id);
    }

    public async Task<Tag> GetByIdAsync(int id)
    {
        var tag = await tagDao.GetByIdAsync(id);

        if (tag == null)
        {
            throw new Exception($"Item with id {id} does not exist.");
        }

        return tag;
    }

    public Task<IEnumerable<Tag>> GetAllWithIdAsync(List<int> ids)
    {
        return tagDao.GetAllWithIdAsync(ids);
    }

    private static void ValidateTag(TagCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Name))
        {
            throw new Exception("Tag may not be empty.");
        }
    }

    private static void ValidateTag(Tag tag)
    {
        if (string.IsNullOrEmpty(tag.TagName))
        {
            throw new Exception("Tag may not be empty.");
        }
    }
}