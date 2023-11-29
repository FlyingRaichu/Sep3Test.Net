using Application.DaoInterfaces;
using Domain.DTOs.Tag;
using RPCInterface.RPCInterfaces;

namespace DataHandling.DAOs;

public class TagDao : ITagDao
{
    private readonly IRpcBase<Tag> context;

    public TagDao(IRpcBase<Tag> context)
    {
        this.context = context;
    }

    public Task<IEnumerable<Tag>> GetAsync(SearchTagParametersDto searchParameters)
    {
        IEnumerable<Tag> tags = context.Elements.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParameters.NameContains))
        {
            tags = context.Elements.Where(tag =>
                tag.TagName.Contains(searchParameters.NameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(tags);
    }

    public Task<Tag> CreateAsync(Tag tag)
    {
        int id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.Id);
            id++;
        }

        tag.Id = id;

        context.Add(tag);
        return Task.FromResult(tag);
    }

    public Task UpdateAsync(Tag tag)
    {
        context.Update(tag);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        context.Delete(id);
        return Task.CompletedTask;
    }

    public Task<Tag?> GetByIdAsync(int id)
    {
        var tag = context.Elements.FirstOrDefault(tag => tag.Id == id);
        return Task.FromResult<Tag>(tag);
    }
}