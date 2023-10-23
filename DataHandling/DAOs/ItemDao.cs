using Application.DaoInterfaces;
using Domain.DTOs;
using RPCInterface.RPCImplementations;
using Via.Sep4.Protobuf;

namespace DataHandling.DAOs;

public class ItemDao : IItemDao
{
    private readonly ItemRpc context;

    public ItemDao(ItemRpc context)
    {
        this.context = context;
    }

    public Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters)
    {
        IEnumerable<Item> items = context.Items.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            items = context.Items.Where(item =>
                item.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(searchParameters.DescriptionContains))
        {
            items = context.Items.Where(item =>
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
        if (context.Items.Any())
        {
            id = context.Items.Max(i => i.Id);
            id++;
        }

        item.Id = id;

        context.Add(item);
        return Task.FromResult(item);
    }
}