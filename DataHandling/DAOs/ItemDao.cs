using Application.DaoInterfaces;
using Domain.DTOs;
using RPCInterface.RPCImplementations;
using Via.Sep4.Protobuf;

namespace DataHandling.DAOs;

public class ItemDao : IItemDao
{
    private readonly IRpcBase<Item> context;

    public ItemDao(IRpcBase<Item> context)
    {
        this.context = context;
    }

    public Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters)
    {
        IEnumerable<Item> items = context.Elements.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            items = context.Elements.Where(item =>
                item.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(searchParameters.DescriptionContains))
        {
            items = context.Elements.Where(item =>
                item.Description.Contains(searchParameters.DescriptionContains, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.Price != null)
        {
            items = items.Where(item => item.Price.Equals(searchParameters.Price));
        }

        return Task.FromResult(items);
    }

    public Task<Item> CreateAsync(Item item)
    {
        int id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.Id);
            id++;
        }

        item.Id = id;

        context.Add(item);
        return Task.FromResult(item);
    }

    public Task UpdateAsync(Item item)
    {
        context.Update(item);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        context.Delete(id);
        return Task.CompletedTask;
    }

    public Task<Item?> GetByIdAsync(int id)
    {
        var item = context.Elements.FirstOrDefault(i => i.Id == id);
        return Task.FromResult<Item>(item);
    }
}